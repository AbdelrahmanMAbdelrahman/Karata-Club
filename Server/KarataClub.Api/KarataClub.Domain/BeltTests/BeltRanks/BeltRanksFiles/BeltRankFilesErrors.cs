using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarataClub.Domain.BeltTests.BeltRanks.BeltRanksFiles
{
    internal class BeltRankFilesErrors
    {
        internal static Result<BeltRankFile> InvalidUploadedFileId;
        internal static Result<BeltRankFile> InvalidBeltRankId;
    }
}
