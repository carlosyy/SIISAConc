using DataManagement;
using Entities;

namespace Business
{
    public class B_Notes
    {
        readonly DM_Notes _oDmNotes = new DM_Notes();

        public int AddNotes(NotesEntidad notes)
        {
            return _oDmNotes.AddNotes(notes);
        }       
    }
}
