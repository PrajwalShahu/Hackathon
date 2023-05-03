namespace Note_CRUD_Exercise
{
    class Note
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
       

        //public int NoteId = 3;

        //public int GenerateId()
        //{
        //    Id = NoteId++;
        //    return Id;
        //}
    }

    class TakeNotes
    {
        List<Note> notes;
        public TakeNotes()
        {
            notes = new List<Note>();            
        }

        public void CreateNote(Note note)
        {
            notes.Add(note);
        }

        public Note ViewNote(int id)
        {
            foreach (Note note in notes)
            {
                if (note.Id == id)
                {
                    return note;
                }
            }
            return null;
        }

        public List<Note> ViewNotes()
        {
            return notes;
        }

        public void UpdateNote()
        {
            Console.WriteLine("Enter the id of the note you want to update:");
            int id = int.Parse(Console.ReadLine());

            Note note1 = notes.Find(n => n.Id == id);

            if (note1 != null)
            {
                Console.WriteLine("Enter the new title of the note:");
                note1.Title = Console.ReadLine();

                Console.WriteLine("Enter the new description of the note:");
                note1.Description = Console.ReadLine();

                note1.Date = DateTime.Now;

                Console.WriteLine("Note updated successfully!");
            }
            else
            {
                Console.WriteLine("Note not found!");
            }
        }

        public bool DeleteNote(int id)
        {
            foreach (Note note in notes)
            {
                if (note.Id == id)
                {
                    notes.Remove(note);
                    return true;
                }
            }
            return false;
        }

        public int GenerateNoteId()
        {
            if (notes.Count > 0)
            {
                return notes[notes.Count - 1].Id + 1;
            }
            else
            {
                return 1;
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            TakeNotes takenotes = new TakeNotes();            
            string ans = "";

            while(true)
            {
                Console.WriteLine("Welcome to the Take Note Applcation");
                Console.WriteLine("1. Create the Note");
                Console.WriteLine("2. View Note  by ID");
                Console.WriteLine("3. View all Notes");
                Console.WriteLine("4. Update Note");
                Console.WriteLine("5. Delete Note by ID");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            Console.WriteLine("Enter Title");
                            string title = Console.ReadLine();
                            Console.WriteLine("Enter Description");
                            string description = Console.ReadLine();
                            int id = takenotes.GenerateNoteId();

                            takenotes.CreateNote(new Note { Id = id, Title = title, Description = description, Date = DateTime.Now });
                            Console.WriteLine("Note added successfully!");
                            break;
                        }

                    case 2:
                        {
                            Console.WriteLine("Enter Note ID");
                            int id = Convert.ToInt32(Console.ReadLine());
                            Note? n = takenotes.ViewNote(id);
                            if (n == null)
                            {
                                Console.WriteLine("Note with specified id does not exists");
                            }
                            else
                            {
                                Console.WriteLine($"{n.Id} {n.Title} {n.Description} {n.Date.ToString("dd-MMM-yyyy")}");
                            }
                            break;
                        }

                    case 3:
                        {
                            Console.WriteLine("{0,-10}{1,-20}{2,-50}{3,-20}", "--", "-----", "-----------", "----");
                            Console.WriteLine("{0,-10}{1,-20}{2,-50}{3,-20}", "id", "title", "description", "date");
                            Console.WriteLine("{0,-10}{1,-20}{2,-50}{3,-20}", "--", "-----", "-----------", "----");
                            foreach (var n in takenotes.ViewNotes())
                            {                                
                                Console.WriteLine("{0,-10}{1,-20}{2,-50}{3,-20}", n.Id, n.Title, n.Description, n.Date.ToString("dd-MMM-yyyy"));
                                //Console.WriteLine($"{n.Id} {n.Title} {n.Description} {n.Date}");                                
                            }
                            Console.WriteLine("Total Notes: {0}\n", takenotes.ViewNotes().Count);
                            break;
                        }

                    case 4:
                        {
                            takenotes.UpdateNote();
                            break;
                        }

                    case 5:
                        {
                            Console.WriteLine("Enter Note Id");
                            int id = Convert.ToInt16(Console.ReadLine());
                            if (takenotes.DeleteNote(id))
                            {
                                Console.WriteLine("Note Deleted Successfully");
                            }
                            else
                            {
                                Console.WriteLine("Note with specified id does not exist");
                            }
                            break;
                        }
                }                
            } 
        }
    }
}