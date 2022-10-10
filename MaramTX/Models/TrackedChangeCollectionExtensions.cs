//namespace MaramTX.Models
//{
  
//        public static class TrackedChangeCollectionExtensions
//        {
//            // removes all changes in the TrackedChangeCollection with a given username
//            public static int RemoveAll(
//                this TXTextControl.TrackedChangeCollection trackdChangeCollection,
//                string username, bool accept)
//            {
//                List<TrackedChange> myTrackedChanges = new List<TrackedChange>();

//                // loop through all changes
//                foreach (TXTextControl.TrackedChange trackedChange in trackdChangeCollection)
//                {
//                    if (trackedChange.UserName == username)
//                        myTrackedChanges.Add(trackedChange);
//                }

//                // delete all changes
//                foreach (TrackedChange listedTrackedChange in myTrackedChanges)
//                    trackdChangeCollection.Remove(listedTrackedChange, true);

//                return myTrackedChanges.Count;
//            }

//            // removes all changes in all TextParts with a given username
//            public static int RemoveAllTrackedChanges(
//                this TXTextControl.TextPartCollection textPartCollection,
//                string username, bool accept)
//            {
//                // counter
//                var deletedTrackedChanges = 0;

//                // loop through all text parts
//                foreach (IFormattedText textPart in textPartCollection)
//                {
//                    List<TrackedChange> myTrackedChanges = new List<TrackedChange>();

//                    // loop through all changes
//                    foreach (TXTextControl.TrackedChange trackedChange in textPart.TrackedChanges)
//                    {
//                        if (trackedChange.UserName == username)
//                            myTrackedChanges.Add(trackedChange);
//                    }

//                    // delete all changes
//                    foreach (TrackedChange listedTrackedChange in myTrackedChanges)
//                    {
//                        textPart.TrackedChanges.Remove(listedTrackedChange, true);
//                        deletedTrackedChanges++;
//                    }
//                }

//                return deletedTrackedChanges;
//            }
//        }
    
//}
