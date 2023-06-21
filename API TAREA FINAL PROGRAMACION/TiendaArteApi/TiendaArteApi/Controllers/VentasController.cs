using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiendaArte.Controllers;
using TiendaArteApi.Datos;
using TiendaArteApi.Models;
using TiendaArteApi.Models.Dto;

namespace TiendaArteApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        private readonly ILogger<VentasController> _logger;
        private readonly TiendaContext _db;

        private readonly IMapper _mapper;

        public VentasController(ILogger<VentasController> logger, TiendaContext db, IMapper mapper)
        {
            _logger = logger;
            _db = db;
            _mapper = mapper;
        }

        #region Get/Mostrar 
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task< ActionResult<IEnumerable<VentasDto>>> GetVentas()
        {
            _logger.LogInformation("Obtener el listado de ventas");
            IEnumerable<Ventas> VentaList = await _db.RegistroVentas.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<VentasDto>>(VentaList));
        }
        #endregion

        #region Get/Consulta
        //METODO GET
        [HttpGet("VentasCode: int", Name = "MostrarVentas")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<VentasDto>> MostrarVentas(int id)
        {
            if (id == 0)   // ERROR 400
            {
                _logger.LogError("Error al Mostrar la venta con id " + id);
                return BadRequest();
            }
            var Venta = await _db.RegistroVentas.FirstOrDefaultAsync(v => v.VentasCode == id);

            if (Venta == null)
            {
                _logger.LogError("Error al intentar buscar la venta.");
                return NotFound(); //ERROR 404 NO ENCONTRADO
            }

            return Ok(_mapper.Map<VentasDto>(Venta));
        }
        #endregion

        #region Get/Consulta_por_nombre
        [HttpGet("ClienteName: string", Name = "MostrarVentasNombre")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<VentasDto>> MostrarVentasNombre(string nombre)
        {
            if (nombre == "")   // ERROR 400
            {
                _logger.LogError("Error al Mostrar la venta con id " + nombre);
                return BadRequest();
            }

            var venta = from a in _db.RegistroVentas where a.ClienteName.Contains(nombre) select a;
            /*_db.RegistroVentas.FirstOrDefault(v => v.ClienteName == nombre);*/

            if (venta == null)
            {
                _logger.LogError("Error al intentar buscar la venta.");
                return NotFound(); //ERROR 404 NO ENCONTRADO
            }

            return Ok(_mapper.Map<VentasDto>(venta));
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
        public async Task<ActionResult<VentasDto>> AgregarLista([FromBody] VentasCreateDto ventasdto) //FROMBODY: Recibir datos
        {

            /*VALIDACION : Model state verifica los campos requeridos, si no tienen informacion, detecta un error e impide el seguimiento 
             * De las siguientes lineas de codigo*/
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            /*VALIDACION: se verifica si el nombre que se desea agregar ya existe en el contexto actual de la lista*/
            if (await _db.RegistroVentas.FirstOrDefaultAsync(v => v.ClienteName.ToLower() == ventasdto.ClienteName.ToLower()) != null)
            { 
                ModelState.AddModelError("NombreExiste", "Ya existe una venta con este nombre");
                return BadRequest(ModelState);
            }

            if (ventasdto == null)
            {
                return BadRequest(ventasdto);
            }

            Ventas modelo = _mapper.Map<Ventas>(ventasdto);

            /*Ventas modelo = new()
            {
                ClienteName = ventasdto.ClienteName,
                Solicitud = ventasdto.Solicitud,
                PrecioVenta = ventasdto.PrecioVenta,
                Direccion = ventasdto.Direccion,
                FechaEntrega = ventasdto.FechaEntrega
            };*/

            await _db.RegistroVentas.AddAsync(modelo);
            await _db.SaveChangesAsync();

            return CreatedAtRoute("MostrarVentas", new { id = modelo.VentasCode }, modelo);
        }
        #endregion

        #region Delete/Eliminar
        //METODO DELETE
        [HttpDelete("VentasCode:int")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EliminarVentas(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var venta = await _db.RegistroVentas.FirstOrDefaultAsync(v => v.VentasCode == id);

            if (venta == null)
            {
                return NotFound();
            }
            _db.RegistroVentas.Remove(venta);
            await _db.SaveChangesAsync();
            return NoContent();
        }
        #endregion

        #region Put/Actualizar
        //METODO PUT
        [HttpPut("VentasCode:int")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ActualizarVentas(int id, [FromBody] VentasUpdateDto ventasdto)
        {
            if (ventasdto == null || id != ventasdto.VentasCode)
            {
                return BadRequest();
            }
            /*var inventario = _db.Productos.FirstOrDefault(v => v.ProductCode == Id);
            inventario.ProductName = inventariodto.ProductName;
            inventario.ProductDescription = inventariodto.ProductDescription;
            inventario.ProductPrice = inventariodto.ProductPrice;
            inventario.ProductUnit = inventariodto.ProductUnit;*/


            Ventas modelo = _mapper.Map<Ventas>(ventasdto);
            /*Ventas modelo = new()
            {
                VentasCode = ventasdto.VentasCode,
                ClienteName = ventasdto.ClienteName,
                Solicitud = ventasdto.Solicitud,
                PrecioVenta = ventasdto.PrecioVenta,
                Direccion = ventasdto.Direccion,
                FechaEntrega = ventasdto.FechaEntrega
            };*/

            _db.RegistroVentas.Update(modelo);
            await _db.SaveChangesAsync();

            return NoContent();
        }
        #endregion

        #region Patch/ActualizarEspecifico
        //METODO PATCH
        [HttpPatch("VentasCode : int")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ActualizarParcialVentas(int id, JsonPatchDocument<VentasUpdateDto> patchDTO)
        {
            if (patchDTO == null || id == 0)
            {
                return BadRequest();
            }

            var venta = await _db.RegistroVentas.FirstOrDefaultAsync(v => v.VentasCode == id);

            VentasUpdateDto ventasdto = _mapper.Map<VentasUpdateDto>(venta);

            /*VentasUpdateDto ventasdto = new()
            {
                ClienteName = venta.ClienteName,
                Solicitud = venta.Solicitud,
                PrecioVenta = venta.PrecioVenta,
                Direccion = venta.Direccion,
                FechaEntrega = venta.FechaEntrega
            };*/

            if (venta == null)
            {
                return BadRequest();
            }

            patchDTO.ApplyTo(ventasdto, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Ventas modelo = _mapper.Map<Ventas>(ventasdto);

            /*
            Ventas modelo = new()
            {
                ClienteName = ventasdto.ClienteName,
                Solicitud = ventasdto.Solicitud,
                PrecioVenta = ventasdto.PrecioVenta,
                Direccion = ventasdto.Direccion,
                FechaEntrega = ventasdto.FechaEntrega
            };*/

            _db.RegistroVentas.Update(modelo);
            await _db.SaveChangesAsync();

            return NoContent();
        }
        #endregion

    }
}
