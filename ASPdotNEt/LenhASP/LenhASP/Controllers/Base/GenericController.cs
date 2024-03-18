using LenhASP.Domain.Services;
using LenhASP.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace LenhASP.Controllers.Base
{
    [ApiController]
    public class GenericController<TKey, TEntity, TContext> : ControllerBase
     where TEntity : class
     where TContext : DbContext
    {
        internal IGenericService<TEntity, TContext> _service;
        public GenericController(IGenericService<TEntity, TContext> service)
        {
            this._service = service;
        }
        //[ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public virtual IActionResult GetAll()
        {
            try
            {
                var result = new { Data = _service.GetList() };
                return Ok(new ResultApi(result));
            }
            catch (Exception ex)
            {
                return BadRequest(new ResultApi(ex));
            }
        }
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public virtual IActionResult GetPagination(int pageIndex = 0, int pageSize = 0)
        {
            try
            {
                var result = new { TotalRow = _service.GetList().Count, Data = _service.GetList(PageIndex: pageIndex, PageSize: pageSize) };
                return Ok(new ResultApi(result));
            }
            catch (Exception ex)
            {
                return BadRequest(new ResultApi(ex));
            }
        }
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public virtual IActionResult GetById(TKey id)
        {
            try
            {
                object data = new();
                if (id != null)
                    data = _service.GetByID(id);
                var result = new { Data = data };
                return Ok(new ResultApi(result));
            }
            catch (Exception ex)
            {
                return BadRequest(new ResultApi(ex));
            }
        }


        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public virtual IActionResult Create(TEntity entity)
        {
            try
            {
                _service.Insert(entity);
                return Ok(new ResultApi(entity));
            }
            catch (Exception ex)
            {
                return BadRequest(new ResultApi(ex));
            }
        }
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public virtual IActionResult CreateRange(IEnumerable<TEntity> entities)
        {
            try
            {
                _service.InsertRange(entities);
                return Ok(new ResultApi(entities));
            }
            catch (Exception ex)
            {
                return BadRequest(new ResultApi(ex));
            }
        }
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public virtual IActionResult Update(TEntity entity)
        {
            try
            {
                _service.Update(entity);
                return Ok(new ResultApi(entity));
            }
            catch (Exception ex)
            {
                return BadRequest(new ResultApi(ex));
            }
        }
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public virtual IActionResult HardDelete(TKey? id)
        {
            try
            {
                if (id != null)
                    _service.TryDelete(id);
                return Ok(new ResultApi(id));
            }
            catch (Exception ex)
            {
                return BadRequest(new ResultApi(ex));
            }
        }
    }
}
