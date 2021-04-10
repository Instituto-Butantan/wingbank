using System;
using System.Collections.Generic;
using System.IO;
using MosquitoLab.Domain.Individuals.Commands.Input;
using MosquitoLab.Domain.Individuals.Commands.Output;
using MosquitoLab.Domain.PakcageGenarator;
using MosquitoLab.Shared.Commands;

namespace MosquitoLab.Domain.Individuals.Handlers
{
    public class WingHandler : ICommandHandler<DownloadWingCommand>
    {
        private readonly IWingbankPackageProcess _packageProcess;

        public WingHandler(IWingbankPackageProcess packageProcess)
        {
            _packageProcess = packageProcess;
        }

        public ICommandResult Handle(DownloadWingCommand command)
        {
            var wings = new List<int>();
            foreach (var wing in command.WingsIds)
            {
                wings.Add(wing);
            }
            var file = _packageProcess.GerarPacote(wings);
            var info = new FileInfo(file);
            return new DownloadWingCommandResult(file, "application/zip", $"{info.Name}");
        }
    }
}
