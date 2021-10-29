﻿using Application.Interfaces;
using Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;


namespace Web.MVC.Controllers
{
    
    public class TransportController : Controller
    {
        private readonly ITransportService _transportService;
        public TransportController(ITransportService transportService)
        {
            _transportService = transportService;
        }

        public IActionResult Index()
        {
            var transportListViewModel = _transportService.GetTransports();
            return View(transportListViewModel);
        }
        
        public IActionResult Add()
        {
           
            return View();
        }
      
        public IActionResult AddTransport(Guid id)
        {

            if (id == Guid.Empty)
            {
                return View();
            }
            var transportVM = _transportService.GetTransportById(id);
            return View(transportVM);
        }
        public IActionResult AddTranport(TransportViewModel transportViewModel)
        {
            if (transportViewModel.Id == Guid.Empty)
            {
                return View();
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult AddTransport(TransportViewModel transportViewModel, int i)
        {
            if (transportViewModel.Id == Guid.Empty)
            {
                _transportService.AddTransport(transportViewModel);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
