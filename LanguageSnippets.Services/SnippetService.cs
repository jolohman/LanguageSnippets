using LanguageSnippets.Contracts;
using LanguageSnippets.Data;
using LanguageSnippets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageSnippets.Services
{
    public class SnippetService : ISnippetService
    {
        private Snippet GetSnippetFromDatabase(ApplicationDbContext context, int snippetId)
        {
            return
                context
                       .Snippets
                       .SingleOrDefault(e => e.SnippetId == snippetId && e.OwnerId == _userId);
        }

        private readonly Guid _userId;

        public SnippetService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateSnippet(SnippetCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                new Snippet()
                {
                    OwnerId = _userId,
                    IsStarred = model.IsStarred,
                    Phrase = model.Phrase,
                    Language = model.Language,
                    Meaning = model.Meaning,
                    CreatedUtc = DateTimeOffset.Now

                };

                ctx.Snippets.Add(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public SnippetDetail GetSnippetById(int Id)
        {
            Snippet entity;

            using (var ctx = new ApplicationDbContext())
            {
                entity = GetSnippetFromDatabase(ctx, Id);
            }

            if (entity == null) return new SnippetDetail();

            return
                new SnippetDetail
                {
                    Phrase = entity.Phrase,
                    Language = entity.Language,
                    Meaning = entity.Meaning,
                    CreatedUtc = entity.CreatedUtc,
                    SnippetId = entity.SnippetId,
                    ModifiedUtc = entity.ModifiedUtc,

                };
        }

        public bool EditSnippet(SnippetEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = GetSnippetFromDatabase(ctx, model.SnippetId);

                if (entity == null) return false;

                entity.IsStarred = model.IsStarred;
                entity.Phrase = model.Phrase;
                entity.Language = model.Language;
                entity.Meaning = model.Meaning;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<SnippetListItem> GetSnippet()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return
                    ctx
                        .Snippets
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new SnippetListItem
                                {
                                    SnippetId = e.SnippetId,
                                    Phrase = e.Phrase,
                                    Meaning = e.Meaning,
                                    IsStarred = e.IsStarred,
                                    Language = e.Language,
                                    CreatedUtc = e.CreatedUtc,
                                    ModifiedUtc = e.ModifiedUtc
                                })
                        .ToArray();
            }
            
        }

        public bool DeleteSnippet(int snippetId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Snippets
                        .Single(e => e.SnippetId == snippetId && e.OwnerId == _userId);

                ctx.Snippets.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
