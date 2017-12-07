﻿using LanguageSnippets.Contracts;
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
        private readonly Guid _userId;

        public SnippetService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateSnippet(SnippetCreate model)
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

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Snippets.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<SnippetListItem> GetSnippet()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Snippets
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new SnippetListItem
                                {
                                    SnippetId = e.SnippetId,
                                    Phrase = e.Phrase,
                                    IsStarred = e.IsStarred,
                                    Language = e.Language,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );

                return query.ToArray();
            }
            
        }
    }
}