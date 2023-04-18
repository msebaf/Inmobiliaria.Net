using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Inmobiliaria.Net.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Inmobiliaria.Net.Controllers
{
    [Authorize]
    public class InquilinosController : Controller
    {
        public readonly BdInquilinos bdInquilinos = new BdInquilinos();
        // GET: Inquilinos
        public ActionResult Index()
        {
            var inquilinos = bdInquilinos.Getinquilinos();
            return View(inquilinos);
        }

        // GET: Inquilinos/Details/5
        public ActionResult Details(int id)
        {
            var prop = bdInquilinos.Getinquilino(id);
            return View(prop);
        }

        // GET: Inquilinos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inquilinos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Inquilino inquilino)
        {
            try
            {
                // TODO: Add insert logic here
                int res = bdInquilinos.Alta(inquilino);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Inquilinos/Edit/5
        public ActionResult Edit(int id)
        {
            var prop = bdInquilinos.Getinquilino(id);
            return View(prop);
        }

        // POST: Inquilinos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Inquilino inquilino)
        {
            try
            {
                // TODO: Add update logic here
                
                bdInquilinos.Actualizar(inquilino);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Inquilinos/Delete/5
        [Authorize(Policy = "Administrador")]
        
        public ActionResult Delete(int id)
        {
           var prop =  bdInquilinos.Getinquilino(id);
            return View(prop);
        }

        // POST: Inquilinos/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Administrador")]
        public ActionResult Delete(int id, Inquilino inquilino)
        {
            try
            {
                // TODO: Add delete logic here
                bdInquilinos.DeleteInquilino(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
