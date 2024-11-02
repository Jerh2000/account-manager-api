using ACCOUNT.MANAGER.API.Data.Models.ParametersEndPoints.Utilidades;
using ACCOUNT.MANAGER.API.Data.Models.ResponsesEndPoints;
using ACCOUNT.MANAGER.API.Services;
using ACCOUNT.MANAGER.API.Utils.Statics;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ACCOUNT.MANAGER.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IUtilidadesServices _utilidadesServices;
        public ClienteController(IUtilidadesServices utilidadesServices)
        {
            this._utilidadesServices = utilidadesServices;
        }

        [HttpGet("GetAllClientes")]
        public async Task<IActionResult> GetAllClientes(string conexion)
        {
            try
            {
                var cliente = await _utilidadesServices.Cliente.GetAllCliente(conexion);

                return  Ok(Functions.ReturnResponseOK(cliente, "OK"));
            }
            catch(Exception ex) 
            {
                return StatusCode(500,((Functions.ReturnResponseError("No se pudo consultar los clientes: " + ex.Message))));
            }
        }

        [HttpGet("GetClienteByCodigo")]
        public async Task<IActionResult> GetClienteByCodigo(string conexion, string codigo)
        {
            try
            {
                var cliente = await _utilidadesServices.Cliente.GetClienteByCodigo(codigo, conexion);
                return Ok(Functions.ReturnResponseOK(cliente, "OK"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ((Functions.ReturnResponseError("No se pudo consultar el clientes: " + ex.Message))));
            }
        }

        [HttpPost("CreateCliente")]
        public async Task<IActionResult> CreateCliente([FromBody] ClienteInsert cliente)
        {
            try
            {
                var response = await _utilidadesServices.Cliente.CreateCliente(cliente);
                return Ok(Functions.ReturnResponseOK(response, "Cliente creado con éxito"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ((Functions.ReturnResponseError("No se pudo crear el clientes: " + ex.Message))));
            }
        }

        [HttpPost("UpdateCliente")]
        public async Task<IActionResult> UpdateCliente([FromBody] ClienteUpdate cliente)
        {
            try
            {
                var response = await _utilidadesServices.Cliente.UpdateCliente(cliente);
                return Ok(Functions.ReturnResponseOK(response, "Cliente actualizado con éxito"));

            }
            catch (Exception ex)
            {
                return StatusCode(500, ((Functions.ReturnResponseError("No se pudo actualizar el cliente: " + ex.Message))));
            }
        }
    }
}
