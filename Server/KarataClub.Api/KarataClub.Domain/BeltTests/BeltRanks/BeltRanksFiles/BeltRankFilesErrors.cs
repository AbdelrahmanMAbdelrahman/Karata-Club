using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarataClub.Domain.BeltTests.BeltRanks.BeltRanksFiles
{
    internal class BeltRankFilesErrors
    {
        internal static Error InvalidUploadedFileId=>Error.Validation("BeltRankFileErrors.InvalidUploadedFileId", "Invalid Uploaded File Id");
        internal static Error InvalidBeltRankId=>Error.Validation("BeltRankFileErrors.", "Invalid Belt Rank Id");
    }
}
