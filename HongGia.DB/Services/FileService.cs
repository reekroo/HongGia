using System;
using System.Collections.Generic;
using System.Linq;

using HongGia.Core.Interfaces.Base;

using HongGia.DB.Models;

namespace HongGia.DB.Services
{
    public class FileService
    {
        public static bool AddFile(IFile file)
        {
            using (var context = new EntitiesDB())
            {
                var save = new File()
                {
                    Name = file.Name,
                    Path = file.Path,
                    Date = DateTime.Now
                };

                context.Files.Add(save);
                context.SaveChanges();

                return true;
            }
        }

        public static bool AddFile(IFile file, PageContent content)
        {
            using (var context = new EntitiesDB())
            {
                var save = new File()
                {
                    Name = file.Name,
                    Path = file.Path,
                    Date = DateTime.Now,
                    PageContent = content
                };

                context.Files.Add(save);
                context.SaveChanges();

                return true;
            }
        }

        public static bool AddFile(IFile file, ICollection<Catigory> catigories)
        {
            using (var context = new EntitiesDB())
            {
                var save = new File()
                {
                    Name = file.Name,
                    Path = file.Path,
                    Date = DateTime.Now,

                    Catigories = catigories
                };

                context.Files.Add(save);
                context.SaveChanges();

                return true;
            }
        }
        
        public static bool AddFile(IFile file, ICollection<Catigory> catigories, PageContent content)
        {
            using (var context = new EntitiesDB())
            {
                var save = new File()
                {
                    Name = file.Name,
                    Path = file.Path,
                    Date = DateTime.Now,
                    PageContent = content,
                    Catigories = catigories
                };

                context.Files.Add(save);
                context.SaveChanges();

                return true;
            }
        }

        public static bool RemoveFile(int fileId)
        {
            using (var context = new EntitiesDB())
            {
                if (context.Files.Any() == false)
                {
                    return false;
                }

                var selectFile = context.Files.FirstOrDefault(f => f.Id == fileId);

                if (selectFile == null)
                {
                    return false;
                }

                context.Files.Remove(selectFile);
                context.SaveChanges();

                return true;
            }
        }

        public static bool RemoveFile(IFile file)
        {
            using (var context = new EntitiesDB())
            {
                if (context.Files.Any() == false)
                {
                    return false;
                }

                var selectFile = context.Files.FirstOrDefault(f => f.Name == file.Name && f.Path == file.Path);

                if (selectFile == null)
                {
                    return false;
                }

                context.Files.Remove(selectFile);
                context.SaveChanges();

                return true;
            }
        }

        //add remove files
    }
}
