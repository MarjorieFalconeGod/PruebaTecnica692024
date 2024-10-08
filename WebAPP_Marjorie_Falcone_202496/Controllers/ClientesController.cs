﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAPI__Marjorie_Falcone_202496.Models;
using WebAPP_Marjorie_Falcone_202496.Data;
using WebAPP_Marjorie_Falcone_202496.Service.Clientes;

namespace WebAPP_Marjorie_Falcone_202496.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IClienteServices _ClienteService;

        public ClientesController(IClienteServices ClienteService)
        {
            _ClienteService = ClienteService;
        }


        public async Task<IActionResult> Actualizar([FromBody] Cliente Cliente)
        {
            var Clientes = await _ClienteService.Actualizar(Cliente);
            return Json(Clientes);
        }

        public async Task<IActionResult> Ver(int codigo)
        {
            var Clientes = await _ClienteService.ver(codigo);
            return Json(Clientes);
        }

        public async Task<IActionResult> Index()
        {
            var Clientes = await _ClienteService.ConsultarTodos();
            return View(Clientes);

        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Guardar([FromBody] Cliente Cliente)
        {
            var Clientes = await _ClienteService.Crear(Cliente);
            return Json(Clientes);
        }


    }
}
