using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NECromanceR {
    public class HitboxHandler {
        private static HitboxHandler instance = null;

        private Dictionary<string, List<Hitbox>> hitboxes = new Dictionary<string, List<Hitbox>>();
        

        public HitboxHandler() {

        }
        
        

        /// <summary>
        /// Add hitbox to the handler.
        /// </summary>
        /// <param name="hitbox">Hitbox to add</param>
        /// <param name="tag">Tag to refer to the hitboxes. If tag already in use, hitboxes are appended to current entry.</param>
        /// <returns>Id of the hitbox. Tag and Id are required to delete a hitbox.</returns>
        public void AddHitbox(Hitbox hitbox, string tag) {
            //If the tag already exists, add this hitbox to the list. 
            if(this.hitboxes.ContainsKey(tag)) {
                this.hitboxes[tag].Add(hitbox);
            } else {
                List<Hitbox> tmp = new List<Hitbox>();
                tmp.Add(hitbox);
                this.hitboxes.Add(tag, tmp);
            }
        }

        /// <summary>
        /// Searches for hitbox with matching id and tag, then deletes it. 
        /// </summary>
        /// <param name="hitbox">Hitbox to delete</param>
        /// <param name="tag">Tag to search in</param>
        /// <returns>True if successful, false if unsuccesful.</returns>
        public bool DeleteHitbox(Hitbox hitbox, string tag) {
            return hitboxes[tag].Remove(hitbox);
        }


        /// <summary>
        /// Remove the specified entry from the HitboxHandler
        /// </summary>
        /// <param name="tag">tag of hitboxes to remove</param>
        public void DeleteHitboxGroup(string tag) {
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
        /// <returns>Tuple of colliding hitboxes, or null if no collision</returns>
        public Tuple<Hitbox, Hitbox> IsColliding(string tag1, string tag2) {
            if(ContainsTag(tag1) && ContainsTag(tag2)) {
                foreach(Hitbox h1 in hitboxes[tag1]) {
                    foreach(Hitbox h2 in hitboxes[tag2]) {
                        if(h1.CheckCollision(h2)) {
                            return new Tuple<Hitbox, Hitbox>(h1, h2);
                        }
                    }
                }
                return null;
            } else {
                return null;
            }
        }
        

        public static HitboxHandler GetInstance() {
            if(instance == null)
                instance = new HitboxHandler();

            return instance;
        }   
    }
    
    
}
