using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace NM_KontaktGramata
{
    public class ContactRepository
    {
        private readonly string _path;
        private List<Contact> _contacts = new();

        public ContactRepository(string path)
        {
            _path = path;

            // Pārbaudām, vai ceļam ir mape
            var dir = Path.GetDirectoryName(Path.GetFullPath(path));
            if (!string.IsNullOrEmpty(dir))
                Directory.CreateDirectory(dir);

            Load();
        }

        public List<Contact> GetAll() => _contacts.ToList();

        public void Add(Contact c)
        {
            c.Validate();
            _contacts.Add(c);
            Save();
        }

        public void Update(Contact c)
        {
            c.Validate();
            int i = _contacts.FindIndex(x => x.Id == c.Id);
            if (i >= 0)
            {
                _contacts[i] = c;
                Save();
            }
        }

        public void Delete(Guid id)
        {
            _contacts.RemoveAll(x => x.Id == id);
            Save();
        }

        public List<Contact> Search(string query)
        {
            if (string.IsNullOrWhiteSpace(query)) return GetAll();
            query = query.ToLower();
            return _contacts.Where(c =>
                c.Name.ToLower().Contains(query) ||
                c.Email.ToLower().Contains(query) ||
                c.Phone.ToLower().Contains(query)).ToList();
        }

        private void Save()
        {
            var json = JsonSerializer.Serialize(_contacts, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_path, json);
        }

        private void Load()
        {
            if (File.Exists(_path))
            {
                var json = File.ReadAllText(_path);
                _contacts = JsonSerializer.Deserialize<List<Contact>>(json) ?? new List<Contact>();
            }
        }
    }
}
