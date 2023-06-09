using BlazorMaster.Shared;
using System.Net.Http.Json;

namespace BlazorMaster.Client.Servicio
{
    public class VentaService : IVentaService
    {
        private readonly HttpClient _http;

        public VentaService(HttpClient http)
        {
            _http = http;
        }

        public async Task<bool> Guardar(VentaDTO ventaDTO)
        {
            var response = await _http.PostAsJsonAsync("api/Venta", ventaDTO);
            var resultado = response.IsSuccessStatusCode;

            return resultado;
        }
    }
}
