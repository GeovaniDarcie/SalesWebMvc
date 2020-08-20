using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Models.ViewModels;
using SalesWebMvc.Services;
using SalesWebMvc.Services.Exceptions;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;
        public SellersController(SellerService sellerService, DepartmentService departmentService){
            _sellerService = sellerService;
            _departmentService = departmentService;
        }
        public IActionResult Index(){
            var list = _sellerService.FindAll();

            return View(list);
        }

        public IActionResult Create(){
            var departments = _departmentService.FindAll();
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller){
            _sellerService.Insert(seller);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id){
            if(id == null){
              return NotFound("teste");
            }

            var obj = _sellerService.FindById(id.Value);
            if(obj == null){
                return NotFound("teste123");
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id){
            _sellerService.Remove(id);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int? id){
            if(id == null){
              return NotFound("teste");
            }

            var obj = _sellerService.FindById(id.Value);
            if(obj == null){
                return NotFound("teste123");
            }

            return View(obj);
        }

        public IActionResult Edit(int? id){
            if(id == null){
                return NotFound();
            }

            var obj = _sellerService.FindById(id.Value);
            if(obj == null){
                return NotFound();
            }

           List<Department> departments = _departmentService.FindAll();
           SellerFormViewModel viewModel = new SellerFormViewModel{
               Seller = obj,
               Departments = departments
           };

           return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Seller seller){
            if(id != seller.Id){
                return BadRequest();
            }
            try{
                  _sellerService.Update(seller);
                  return RedirectToAction("Index");
            } catch (NotFoundException){
                return NotFound();
            }
            catch (DbConcurrencyException){
                return BadRequest();
            }
          
        }
    }
}