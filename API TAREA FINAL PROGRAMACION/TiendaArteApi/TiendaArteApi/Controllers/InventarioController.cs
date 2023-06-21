using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiendaArteApi.Datos;
using TiendaArteApi.Models;
using TiendaArteApi.Models.Dto;

namespace TiendaArte.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventarioController : ControllerBase
    {
        //INYECCION DE PROCEDENCIA
        /*Se crean redes privadas readonly donde se inyectan los siguientes servicios de referencia
         *Illoger */
        private readonly ILogger<InventarioController> _logger;
        private readonly TiendaContext _db;
        private readonly IMapper _mapper;

        public InventarioController(ILogger<InventarioController> logger, TiendaContext db, IMapper mapper)
        {
            _logger = logger;
            _db = db;
            _mapper = mapper;
        }

        #region REQUEST Y RESPONSE

        #region Get/Mostrar
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<InventarioDto>>> GetInventario()
        {
            _logger.LogInformation("Obtener el listado de Inventario");
            IEnumerable<Inventario> ProductList = await _db.Productos.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<InventarioDto>>(ProductList));
        }
        #endregion

        #region Get/Consulta
        //METODO GET
        [HttpGet("ProductCode: string", Name = "MostrarInventario")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<InventarioDto>> MostrarInventario(string id)
        {
            if (id == "")   // ERROR 400
            {
                _logger.LogError("Error al Mostrar el producto con id " + id);
                return BadRequest();
            }
            var Inventario = await _db.Productos.FirstOrDefaultAsync(v => v.ProductCode == id);

            if (Inventario == null)
            {
                _logger.LogError("Error al intentar buscar el producto."); 
                return NotFound(); //ERROR 404 NO ENCONTRADO
            }

            return Ok(_mapper.Map<InventarioDto>(Inventario));
        }
        #endregion

        #region Get/Consulta_por_nombre
        [HttpGet("ProductName: string", Name = "MostrarInventarioNombre")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<InventarioDto>> MostrarInventarioNombre(string nombre)
        {
            if (nombre == "")   // ERROR 400
            {
                _logger.LogError("Error al Mostrar el inventario con id " + nombre);
                return BadRequest();
            }
            var inventario = await _db.Productos.AllAsync(v => v.ProductName == nombre);

            if (inventario == null)
            {
                _logger.LogError("Error al intentar buscar el inventario.");
                return NotFound(); //ERROR 404 NO ENCONTRADO
            }

            return Ok(_mapper.Map<InventarioDto>(inventario));
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
        public async Task<ActionResult<InventarioDto>> AgregarLista([FromBody] InventarioCreateDto inventariodto) //FROMBODY: Recibir datos
        {

            /*VALIDACION : Model state verifica los campos requeridos, si no tienen informacion, detecta un error e impide el seguimiento 
             * De las siguientes lineas de codigo*/
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            /*VALIDACION: se verifica si el nombre que se desea agregar ya existe en el contexto actual de la lista*/
            if (await _db.Productos.FirstOrDefaultAsync(v => v.ProductName.ToLower() == inventariodto.ProductName.ToLower()) != null)
            {
                ModelState.AddModelError("NombreExiste", "Ya existe un producto con este nombre");
                return BadRequest(ModelState);
            }

            if (inventariodto == null)
            {
                return BadRequest(inventariodto);
            }

            int id = _db.Productos.Count() + 1;

            Inventario modelo = _mapper.Map<Inventario>(inventariodto);

            /*Inventario modelo = new()
            {
                ProductName = inventariodto.ProductName,
                ProductDescription = inventariodto.ProductDescription,
                ProductPrice = inventariodto.ProductPrice,
                ProductUnit = inventariodto.ProductUnit
            };*/

            await _db.Productos.AddAsync(modelo);
            await _db.SaveChangesAsync();

            return CreatedAtRoute("MostrarInventario", new {id = modelo.ProductCode = "PROD-" + id}, modelo);
        }
        #endregion

        #region Delete/Eliminar
        //METODO DELETE
        [HttpDelete("ProductCode:string")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EliminarInventario(string id)
        {
            if (id == "")
            {
                return BadRequest();
            }

            var producto = await _db.Productos.FirstOrDefaultAsync(v => v.ProductCode == id);

            if (producto == null)
            {
                return NotFound();
            }
            _db.Productos.Remove(producto);
            await _db.SaveChangesAsync();
            return NoContent();
        }
        #endregion

        #region Put/Actualizar
        //METODO PUT
        [HttpPut("ProductCode:string")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ActualizarInventario(string id, [FromBody] InventarioUpdateDto inventariodto)
        {
            if (inventariodto == null || id != inventariodto.ProductCode)
            {
                return BadRequest();
            }
            /*var inventario = _db.Productos.FirstOrDefault(v => v.ProductCode == Id);
            inventario.ProductName = inventariodto.ProductName;
            inventario.ProductDescription = inventariodto.ProductDescription;
            inventario.ProductPrice = inventariodto.ProductPrice;
            inventario.ProductUnit = inventariodto.ProductUnit;*/

            Inventario modelo = _mapper.Map<Inventario>(inventariodto);

            /*Inventario modelo = new()
            {
                ProductName = inventariodto.ProductName,
                ProductDescription = inventariodto.ProductDescription,
                ProductPrice = inventariodto.ProductPrice,
                ProductUnit = inventariodto.ProductUnit
            };*/

            _db.Productos.Update(modelo);
            await _db.SaveChangesAsync();

            return NoContent();
        }
        #endregion

        #region Patch/ActualizarEspecifico
        //METODO PATCH
        [HttpPatch("ProductCode : string")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ActualizarParcialInventario(string id, JsonPatchDocument<InventarioUpdateDto> patchDTO)
        {
            if (patchDTO == null || id == "" )
            {
                return BadRequest();
            }

            var producto =  await _db.Productos.FirstOrDefaultAsync(v => v.ProductCode == id);

            InventarioUpdateDto productoDto = _mapper.Map<InventarioUpdateDto>(producto);

            /*InventarioUpdateDto inventariodto = new()
            {
                ProductName = producto.ProductName,
                ProductDescription = producto.ProductDescription,
                ProductPrice = producto.ProductPrice,
                ProductUnit = producto.ProductUnit
            };*/

            if (producto==null)
            {
                return BadRequest();
            }

            patchDTO.ApplyTo(productoDto, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Inventario modelo = _mapper.Map<Inventario>(productoDto);

            /*Inventario modelo = new()
            {
                ProductName = inventariodto.ProductName,
                ProductDescription = inventariodto.ProductDescription,
                ProductPrice = inventariodto.ProductPrice,
                ProductUnit = inventariodto.ProductUnit
            };*/

            _db.Productos.Update(modelo);
            await _db.SaveChangesAsync();

            return NoContent();
        }
        #endregion

        #endregion
    }


}
