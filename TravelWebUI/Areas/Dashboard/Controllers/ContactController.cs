﻿using Business.Abstract;
using Core.Result.Contrete;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TravelWebUI.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }
        public IActionResult Index()
        {
            var data = _contactService.GetAll().Data;
            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ContactCreateDto dto)
        {
            var result = _contactService.Add(dto);

            if (!result.IsSuccess)
            {
                ModelState.Clear();
                ModelState.AddModelError("", result.Message);
                return View(dto);

            }
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var data = _contactService.GetbyId(id).Data;

            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(ContactUpdateDto dto)
        {
            var result = _contactService.Update(dto);

            if (result.IsSuccess) return RedirectToAction("Index");

            return View(dto);
        }

        [HttpPost]
        public IActionResult Update(ContactUpdateDto dto)
        {
            var result = _contactService.Update(dto);

            if (result.IsSuccess)
                return RedirectToAction("Index");

            return View(dto);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _contactService.Delete(id);    

            if(result.IsSuccess)
                return RedirectToAction("Index");

            return View(result);
        }
    }
}
