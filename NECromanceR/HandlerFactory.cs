using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NECromanceR {
    public static class HandlerFactory {

        public static Handler GetHandler ( HandlerType type ) {
            switch ( type ) {
                case HandlerType.HITBOX_HANDLER:
                    return new HitboxHandler();
                default: return null;
            }
        }

    }
}
