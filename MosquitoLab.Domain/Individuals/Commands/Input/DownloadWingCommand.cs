using System;
using System.Collections.Generic;
using System.Linq;
using MosquitoLab.Shared.Commands;

namespace MosquitoLab.Domain.Individuals.Commands.Input
{
    public class DownloadWingCommand : ICommand
    {
        public string Files { get; set; }

        public IEnumerable<int> WingsIds
        {
            get
            {
                if (string.IsNullOrEmpty(Files)) return new List<int>();
                var ids = Files.Split(',');
                return ids.Select(x => Convert.ToInt32(x));
            }
        }

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(Files) || !WingsIds.Any();
        }
    }
}
