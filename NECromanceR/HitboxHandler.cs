using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NECromanceR {
    public class HitboxHandler {
        private static HitboxHandler instance = null;

        private Dictionary<string, HitboxInfo> hitboxes = new Dictionary<string, HitboxInfo>();

        public HitboxHandler() {

        }

        /// <summary>
        /// Add list of hitboxes to the handler.
        /// </summary>
        /// <param name="parent">Parent entity</param>
        /// <param name="hitboxes">List of hitboxes to add</param>
        /// <param name="tag">Tag to refer to the hitboxes. If tag already in use, hitboxes are appended to current entry.</param>
        public void AddHitbox(Object parent, List<Hitbox> hitboxes, string tag) {
            //If the tag already exists, add these hitboxes to the list. 
            if(this.hitboxes.ContainsKey(tag)) {
                foreach(Hitbox h in hitboxes)
                    this.hitboxes[tag].Hitboxes.Add(h);
            } else {
                //If tag doesn't exist, add it. 
                this.hitboxes.Add(tag, new HitboxInfo(parent, hitboxes));
            }
        }

        /// <summary>
        /// Remove the specified entry from the HitboxHandler
        /// </summary>
        /// <param name="tag">tag of hitboxes to remove</param>
        public void DeleteHitbox(string tag) {
            hitboxes.Remove(tag);
        }

        /// <summary>
        /// Check to see if HitboxManager contains an entry for the specified tag
        /// </summary>
        /// <param name="tag">Tag to search for</param>
        /// <returns></returns>
        public bool ContainsTag(string tag) {
            return hitboxes.ContainsKey(tag);
        }


        /// <summary>
        /// Checks to see if any hitbox marked with tag1 is colliding with any hitbox marked with tag2
        /// </summary>
        /// <param name="tag1"></param>
        /// <param name="tag2"></param>
        /// <returns></returns>
        public bool IsColliding(string tag1, string tag2) {
            if(ContainsTag(tag1) && ContainsTag(tag2)) {
                foreach(Hitbox h1 in hitboxes[tag1].Hitboxes) {
                    foreach(Hitbox h2 in hitboxes[tag2].Hitboxes) {
                        if(h1.CheckCollision(h2)) {
                            return true;
                        }
                    }
                }
                return false;
            } else {
                return false;
            }
        }

        public static HitboxHandler GetInstance() {
            if(instance == null)
                instance = new HitboxHandler();

            return instance;
        }   
    }



    //Contain reference to parent object and a list of hitboxes that relate to it
    public class HitboxInfo {
        public Object Parent { get; private set; }
        public List<Hitbox> Hitboxes { get; private set; }

        public HitboxInfo(Object parent, List<Hitbox> hitboxes) {
            Parent = parent;
            Hitboxes = hitboxes;
        }
    }
}
