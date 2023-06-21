using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using TiendaArteApi.Datos;
using TiendaArteApi.Models.Dto;
using TiendaArteApi.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace TiendaArteApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComisionesController : ControllerBase
    {
        private readonly ILogger<ComisionesController> _logger;
        private readonly TiendaContext _db;
        private readonly IMapper _mapper;

        public ComisionesController(ILogger<ComisionesController> logger, TiendaContext db, IMapper mapper)
        {
            _logger = logger;
            _db = db;
            _mapper = mapper;
        }

        #region Get/Mostrar 
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ComisionDto>>> GetComisiones()
        {
            _logger.LogInformation("Obtener el listado de comisiones");
            IEnumerable<Comisiones> ComisionList = await _db.RegistroComision.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<ComisionDto>>(ComisionList));
        }
        #endregion

        #region Get/Consulta_por_id
        //METODO GET
        [HttpGet("ComisionCode: int", Name = "MostrarComisiones")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ComisionDto>> MostrarComisiones(int id)
        {
            if (id == 0)   // ERROR 400
            {
                _logger.LogError("Error al Mostrar la comision con id " + id);
                return BadRequest();
            }
            var comision = await _db.RegistroComision.FirstOrDefaultAsync(v => v.ComisionCode == id);

            if (comision == null)
            {
                _logger.LogError("Error al intentar buscar la comision.");
                return NotFound(); //ERROR 404 NO ENCONTRADO
            }

            return Ok(_mapper.Map<ComisionDto>(comision));
        }
        #endregion

        #region Get/Consulta_por_nombre
        [HttpGet("ClienteName: string", Name = "MostrarComisionesNombre")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ComisionDto>> MostrarComisionesNombre(string nombre)
        {
            if (nombre == "")   // ERROR 400
            {
                _logger.LogError("Error al Mostrar la comision con id " + nombre);
                return BadRequest();
            }

            var comision = from a in _db.RegistroComision where a.ClienteName.Contains(nombre) select a;

            if (comision == null)
            {
                _logger.LogError("Error al intentar buscar la comision.");
                return NotFound(); //ERROR 404 NO ENCONTRADO
            }

            return Ok(_mapper.Map<ComisionDto>(comision));
        }

        #endregion

        #region Post/Crear
        //METODO POST
        //CREACION DE UN NUEVO PRODUCTO
        //!!! CREACION AUTOMATICA DE UN ID INCREMENTAL "POST-"+{X-1}
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ComisionDto>> AgregarLista([FromBody] ComisionCreateDto comisionesdto) //FROMBODY: Recibir datos
        {

            /*VALIDACION : Model state verifica los campos requeridos, si no tienen informacion, detecta un error e impide el seguimiento 
             * De las siguientes lineas de codigo*/
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            /*VALIDACION: se verifica si el nombre que se desea agregar ya existe en el contexto actual de la lista*/
            if (await _db.RegistroComision.FirstOrDefaultAsync(v => v.ClienteName.ToLower() == comisionesdto.ClienteName.ToLower()) != null)
            {
                ModelState.AddModelError("NombreExiste", "Ya existe una comision con este nombre");
                return BadRequest(ModelState);
            }

            if (comisionesdto == null)
            {
                return BadRequest(comisionesdto);
            }

            Comisiones modelo = _mapper.Map<Comisiones>(comisionesdto);

            /*Comisiones modelo = new()
            {
                ClienteName = comisionesdto.ClienteName,
                Descripcion = comisionesdto.Descripcion,
                Direccion = comisionesdto.Direccion,
                FechaEntrega = comisionesdto.FechaEntrega
            };*/

            await _db.RegistroComision.AddAsync(modelo);
            await _db.SaveChangesAsync();

            return CreatedAtRoute("MostrarComisiones", new { id = modelo.ComisionCode }, modelo);
        }
        #endregion

        #region Delete/Eliminar
        //METODO DELETE
        [HttpDelete("ComisionCode:int")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EliminarComisiones(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var comision = await _db.RegistroComision.FirstOrDefaultAsync(v => v.ComisionCode == id);

            if (comision == null)
            {
                return NotFound();
            }
            _db.RegistroComision.Remove(comision);
            await _db.SaveChangesAsync();
            return NoContent();
        }
        #endregion

        #region Put/Actualizar
        //METODO PUT
        [HttpPut("ComisionCode:int")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ActualizarComisiones(int id, [FromBody] ComisionUpdateDto comisionesdto)
        {
            if (comisionesdto == null || id!= comisionesdto.ComisionCode )
            {
                return BadRequest();
            }

            Comisiones modelo = _mapper.Map<Comisiones>(comisionesdto);

            /*Comisiones modelo = new()
            {
                ComisionCode = comisionesdto.ComisionCode,
                ClienteName = comisionesdto.ClienteName,
                Descripcion = comisionesdto.Descripcion,
                Direccion = comisionesdto.Direccion,
                FechaEntrega = comisionesdto.FechaEntrega
            };*/

            _db.RegistroComision.Update(modelo);
            await _db.SaveChangesAsync();

            return NoContent();
        }
        #endregion

        #region Patch/ActualizarEspecifico
        //METODO PATCH
        [HttpPatch("ComisionCode : int")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ActualizarParcialComisiones(int id, JsonPatchDocument<ComisionUpdateDto> patchDTO)
        {
            if (patchDTO == null || id == 0)
            {
                return BadRequest();
            }

            var comision = await _db.RegistroComision.FirstOrDefaultAsync(v => v.ComisionCode == id);

            ComisionUpdateDto comisionesdto = _mapper.Map<ComisionUpdateDto>(comision);

            /*ComisionUpdateDto comisionesdto = new()
            {
                ClienteName = comision.ClienteName,
                Descripcion = comision.Descripcion,
                Direccion = comision.Direccion,
                FechaEntrega = comision.FechaEntrega
            };*/

            if (comision == null)
            {
                return BadRequest();
            }

            patchDTO.ApplyTo(comisionesdto, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Comisiones modelo = _mapper.Map<Comisiones>(comisionesdto);

            /*Comisiones modelo = new()
            {
                ClienteName = comisionesdto.ClienteName,
                Descripcion = comisionesdto.Descripcion,
                Direccion = comisionesdto.Direccion,
                FechaEntrega = comisionesdto.FechaEntrega
            };*/

            _db.RegistroComision.Update(modelo);
            await _db.SaveChangesAsync();

            return NoContent();
        }
        #endregion
    }
}
