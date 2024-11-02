using ACCOUNT.MANAGER.API.Data.Models.ParametersEndPoints.Utilidades;
using ACCOUNT.MANAGER.API.Services;
using ACCOUNT.MANAGER.API.Utils.Statics;
using Microsoft.AspNetCore.Mvc;

namespace ACCOUNT.MANAGER.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TerceroController : Controller
    {
        private readonly IUtilidadesServices _utilidadesServices;
        public TerceroController(IUtilidadesServices utilidadesServices)
        {
            this._utilidadesServices = utilidadesServices;
        }

        [HttpGet("GetAllTerceros")]
        public async Task<IActionResult> GetAllTerceros(string conexion)
        {
            try
            {
                var cliente = await _utilidadesServices.Tercero.GetAllTercero(conexion);

                return Ok(Functions.ReturnResponseOK(cliente, "OK"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ((Functions.ReturnResponseError("No se pudo consultar los terceros: " + ex.Message))));
            }
        }

        [HttpGet("GetTerceroByCodigo")]
        public async Task<IActionResult> GetTerceroByCodigo(string conexion, string codigo)
        {
            try
            {
                var cliente = await _utilidadesServices.Tercero.GetTerceroByCodigo(codigo, conexion);
                return Ok(Functions.ReturnResponseOK(cliente, "OK"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ((Functions.ReturnResponseError("No se pudo consultar el tercero: " + ex.Message))));
            }
        }

        [HttpPost("CreateTercero")]
        public async Task<IActionResult> CreateTercero([FromBody] TerceroInsert tercero)
        {
            try
            {
                var response = await _utilidadesServices.Tercero.CreateTercero(tercero);
                return Ok(Functions.ReturnResponseOK(response, "Tercero creado con éxito"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ((Functions.ReturnResponseError("No se pudo crear el clientes: " + ex.Message))));
            }
        }

        [HttpPost("UpdateTercero")]
        public async Task<IActionResult> UpdateTercero([FromBody] TerceroUpdate tercero)
        {
            try
            {
                var response = await _utilidadesServices.Tercero.UpdateTercero(tercero);
                return Ok(Functions.ReturnResponseOK(response, "Tercero actualizado con éxito"));

            }
            catch (Exception ex)
            {
                return StatusCode(500, ((Functions.ReturnResponseError("No se pudo actualizar el tercero: " + ex.Message))));
            }
        }
    }
}
