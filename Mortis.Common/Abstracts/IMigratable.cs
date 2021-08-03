using EeveeTools.Database;

namespace Mortis.Common.Abstracts {
    public interface IMigratable {
        void Create(DatabaseContext ctx);
        void Drop(DatabaseContext ctx);
    }
}
