using System;
using System.Web.Mvc;
using MosquitoLab.Domain.Individuals.Commands.Input;
using MosquitoLab.Domain.Individuals.Commands.Output;
using MosquitoLab.Domain.Individuals.Handlers;

namespace MosquitoLab.WingBank.Controllers
{
    public class DownloadController : Controller
    {
        private readonly WingHandler _handler;

        public DownloadController(WingHandler handler)
        {
            _handler = handler;
        }

        public FileResult Wings(DownloadWingCommand command)
        {
            var result = (DownloadWingCommandResult)_handler.Handle(command);
            if (!command.IsValid()) return null;
            return File(result.FileName, result.ContentType,  result.DownloadFileName);
        }
    }
}