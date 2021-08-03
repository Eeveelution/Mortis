using EeveeTools.Database;
using Mortis.Common.Abstracts;

namespace Mortis.Common.Objects {
    public class UserStats : IMigratable {
        public long UserId { get; set; }
        public byte Mode { get; set; }

        public ulong RankedScore { get; set; }
        public ulong TotalScore { get; set; }
        public ulong Performance { get; set; }
        public ulong Playcount { get; set; }
        public double Accuracy { get; set; }
        public uint MaxCombo { get; set; }

        public void Create(DatabaseContext ctx) {
            throw new System.NotImplementedException();
        }
        public void Drop(DatabaseContext ctx) {
            throw new System.NotImplementedException();
        }
    }
}
