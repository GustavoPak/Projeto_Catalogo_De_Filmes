using CatalogoFilmes.Domain.Utilities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CatalogoFilmes.Application.Middlewares
{
    public class ExceptionMiddlware
    {
        private readonly RequestDelegate _next;
        private readonly IWebHostEnvironment _environmentHost;

        public ExceptionMiddlware(RequestDelegate next, IWebHostEnvironment environmentHost)
        {
            _next = next;
            _environmentHost = environmentHost;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var response = new Notification(EnumTipoNofication.ServerError, 
                    $"Ocorreeu um error interno: {(_environmentHost.IsDevelopment() ? ex.Message : "")}");

                await context.Response.WriteAsync(JsonSerializer.Serialize(response));
            }
        }
    }
    
}
