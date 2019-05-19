using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Modelo.Discente;
using Capitulo01.Data.DAL.Discente;
using Capitulo01.Data;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.FileProviders;

namespace Capitulo01.Areas.Discente.Controllers
{
    [Area("Discente")]
    public class AcademicoController : Controller
    {
        private readonly IESContext _context;
        private IHostingEnvironment _env;
        private readonly AcademicoDAL academicoDAL;

        public AcademicoController(IESContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
            academicoDAL = new AcademicoDAL(context);
        }

        public async Task<FileResult> DownloadFoto(long id)
        {
            Academico academico = await academicoDAL.ObterAcademicoPorId(id);
            string nomeArquivo = "Foto" + academico.AcademicoID.ToString().Trim() + ".jpg";
            FileStream fileStream = new FileStream(System.IO.Path.Combine(_env.WebRootPath, nomeArquivo), FileMode.Create, FileAccess.Write);
            fileStream.Write(academico.foto, 0, academico.foto.Length);
            fileStream.Close();

            IFileProvider provider = new PhysicalFileProvider(_env.WebRootPath);
            IFileInfo fileInfo = provider.GetFileInfo(nomeArquivo);
            var readStream = fileInfo.CreateReadStream();
            return File(readStream,academico.FotoMimeType,nomeArquivo);
        }

        public async Task<FileContentResult> GetFoto(long id)
        {
            Academico academico = await academicoDAL.ObterAcademicoPorId(id);
            if(academico != null)
            {
                return File(academico.foto, academico.FotoMimeType);
            }
            return null;
        }

        public async Task<IActionResult> Index()
        {
            return View(await academicoDAL.ObterAcademicosClassificadosProNome().ToListAsync());
        }

        private async Task<IActionResult> ObterVisaoAcademicoPorId(long? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var academico = await academicoDAL.ObterAcademicoPorId((long)id);

            if(academico == null)
            {
                return NotFound();
            }

            return View(academico);
        }

        public async Task<IActionResult> Details(long? id)
        {
            return await ObterVisaoAcademicoPorId(id);
        }

        public async Task<IActionResult> Edit(long? id)
        {
            return await ObterVisaoAcademicoPorId(id);
        }

        public async Task<IActionResult> Delete(long? id)
        {
            return await ObterVisaoAcademicoPorId(id);
        }

        //GET: Academico/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]        
        public async Task<IActionResult> Create([Bind("Nome,RegistroAcademico,Nascimento")] Academico academico, IFormFile foto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var stream = new MemoryStream();
                    await foto.CopyToAsync(stream);
                    academico.foto = stream.ToArray();
                    academico.FotoMimeType = foto.ContentType;
                    await academicoDAL.GravarAcademico(academico);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("","Não foi possível inserir os dados");
            }
            return View(academico);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id,[Bind("AcademicoID,Nome,RegistroAcademico,Nascimento")] Academico academico, IFormFile foto, string chkRemoverFoto)
        {
            if(id != academico.AcademicoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var stream = new MemoryStream();
                if (chkRemoverFoto != null)
                {
                    academico.foto = null;
                }
                else
                {
                    await foto.CopyToAsync(stream);
                    academico.foto = stream.ToArray();
                    academico.FotoMimeType = foto.ContentType;
                }
                try
                {
                    await academicoDAL.GravarAcademico(academico);
                }

                catch (DbUpdateConcurrencyException)
                {
                    if(!await AcademicoExists(academico.AcademicoID))
                    {
                        return NotFound();
                    }
                    else { throw; }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(academico);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            var academico = await academicoDAL.EliminarAcademicoPorId((long)id);
            TempData["Message"] = "Academico " + academico.Nome.ToUpper() + " foi removida";
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> AcademicoExists(long? id)
        {
            return await academicoDAL.ObterAcademicoPorId((long)id) != null;
        }
    }
}