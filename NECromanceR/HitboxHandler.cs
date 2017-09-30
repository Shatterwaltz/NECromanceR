using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NECromanceR {
    public class HitboxHandler : Handler {
        public HitboxHandler () : base() {
        }

        public HitboxHandler ( IList<object> items ) : base( items ) {
        }

        public override bool Equals ( object obj ) {
            return base.Equals( obj );
        }

        public override int GetHashCode () {
            return base.GetHashCode();
        }

        public override string ToString () {
            return base.ToString();
        }
    }
}
