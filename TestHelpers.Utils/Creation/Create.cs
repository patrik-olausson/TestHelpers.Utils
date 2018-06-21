using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHelpers.Utils
{
    public class Create
    {
        public static ACreator A => new ACreator();
        public static AnCreator An => new AnCreator();
    }    
}