using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Concurrent;
using System.Linq.Expressions;

namespace EFCoreCompile
{
    public static class EFWrap
    {
        // Each overload shares this cache; the tuple key prevents boxing/casting issues for
        // lookups.
        private static readonly ConcurrentDictionary<(object model, LambdaExpression expr), object> _cache = new();

        public static Func<TContext, IEnumerable<TResult>> CompileQuery<TContext, TResult>(
            Expression<Func<TContext, DbSet<TResult>>> queryExpression)
            where TContext : DbContext

            where TResult : class
        {
            return (ctx) =>
            {
                var key = (model: (object)ctx.Model, expr: (LambdaExpression)queryExpression);
                var compiled = (Func<TContext, IEnumerable<TResult>>)_cache.GetOrAdd(
                    key,
                    _ => EF.CompileQuery(queryExpression));
                return compiled(ctx);
            };
        }
        public static Func<TContext, IEnumerable<TResult>> CompileQuery<TContext, TResult,
                                                                        TProperty>(
            Expression<Func<TContext, IIncludableQueryable<TResult, TProperty>>> queryExpression)
            where TContext : DbContext
        {
            return (ctx) =>
            {
                var key = (model: (object)ctx.Model, expr: (LambdaExpression)queryExpression);
                var compiled = (Func<TContext, IEnumerable<TResult>>)_cache.GetOrAdd(
                    key,
                    _ => EF.CompileQuery(queryExpression));
                return compiled(ctx);
            };
        }
        public static Func<TContext, IEnumerable<TResult>> CompileQuery<TContext, TResult>(
            Expression<Func<TContext, IQueryable<TResult>>> queryExpression)
            where TContext : DbContext
        {
            return (ctx) =>
            {
                var key = (model: (object)ctx.Model, expr: (LambdaExpression)queryExpression);
                var compiled = (Func<TContext, IEnumerable<TResult>>)_cache.GetOrAdd(
                    key,
                    _ => EF.CompileQuery(queryExpression));
                return compiled(ctx);
            };
        }
        public static Func<TContext, TResult> CompileQuery<TContext, TResult>(
            Expression<Func<TContext, TResult>> queryExpression)
            where TContext : DbContext
        {
            return (ctx) =>
            {
                var key = (model: (object)ctx.Model, expr: (LambdaExpression)queryExpression);
                var compiled = (Func<TContext, TResult>)_cache.GetOrAdd(
                    key,
                    _ => EF.CompileQuery(queryExpression));
                return compiled(ctx);
            };
        }
        public static Func<TContext, TParam1, IEnumerable<TResult>> CompileQuery<
            TContext, TParam1, TResult, TProperty>(
            Expression<Func<TContext, TParam1, IIncludableQueryable<TResult, TProperty>>>
                queryExpression)
            where TContext : DbContext
        {
            return (ctx, p1) =>
            {
                var key = (model: (object)ctx.Model, expr: (LambdaExpression)queryExpression);
                var compiled = (Func<TContext, TParam1, IEnumerable<TResult>>)_cache.GetOrAdd(
                    key,
                    _ => EF.CompileQuery(queryExpression));
                return compiled(ctx, p1);
            };
        }
        public static Func<TContext, TParam1, IEnumerable<TResult>> CompileQuery<TContext, TParam1, TResult>(
            Expression<Func<TContext, TParam1, IQueryable<TResult>>> queryExpression)
            where TContext : DbContext
        {
            return (ctx, p1) =>
            {
                var key = (model: (object)ctx.Model, expr: (LambdaExpression)queryExpression);
                var compiled = (Func<TContext, TParam1, IEnumerable<TResult>>)_cache.GetOrAdd(
                    key,
                    _ => EF.CompileQuery(queryExpression));
                return compiled(ctx, p1);
            };
        }
        public static Func<TContext, TParam1, TResult> CompileQuery<TContext, TParam1, TResult>(
            Expression<Func<TContext, TParam1, TResult>> queryExpression)
            where TContext : DbContext
        {
            return (ctx, p1) =>
            {
                var key = (model: (object)ctx.Model, expr: (LambdaExpression)queryExpression);
                var compiled = (Func<TContext, TParam1, TResult>)_cache.GetOrAdd(
                    key,
                    _ => EF.CompileQuery(queryExpression));
                return compiled(ctx, p1);
            };
        }
        public static Func<TContext, TParam1, TParam2, IEnumerable<TResult>> CompileQuery<
            TContext, TParam1, TParam2, TResult, TProperty>(
            Expression<Func<TContext, TParam1, TParam2, IIncludableQueryable<TResult, TProperty>>>
                queryExpression)
            where TContext : DbContext
        {
            return (ctx, p1, p2) =>
            {
                var key = (model: (object)ctx.Model, expr: (LambdaExpression)queryExpression);
                var compiled =
                    (Func<TContext, TParam1, TParam2, IEnumerable<TResult>>)_cache.GetOrAdd(
                        key,
                        _ => EF.CompileQuery(
                            queryExpression));
                return compiled(ctx, p1, p2);
            };
        }
        public static Func<TContext, TParam1, TParam2, IEnumerable<TResult>> CompileQuery<TContext, TParam1, TParam2, TResult>(
            Expression<Func<TContext, TParam1, TParam2, IQueryable<TResult>>> queryExpression)
            where TContext : DbContext
        {
            return (ctx, p1, p2) =>
            {
                var key = (model: (object)ctx.Model, expr: (LambdaExpression)queryExpression);
                var compiled =
                    (Func<TContext, TParam1, TParam2, IEnumerable<TResult>>)_cache.GetOrAdd(
                        key,
                        _ => EF.CompileQuery(queryExpression));
                return compiled(ctx, p1, p2);
            };
        }
        public static Func<TContext, TParam1, TParam2, TResult> CompileQuery<TContext, TParam1, TParam2, TResult>(
            Expression<Func<TContext, TParam1, TParam2, TResult>> queryExpression)
            where TContext : DbContext
        {
            return (ctx, p1, p2) =>
            {
                var key = (model: (object)ctx.Model, expr: (LambdaExpression)queryExpression);
                var compiled = (Func<TContext, TParam1, TParam2, TResult>)_cache.GetOrAdd(
                    key,
                    _ => EF.CompileQuery(queryExpression));
                return compiled(ctx, p1, p2);
            };
        }
        public static Func<TContext, TParam1, TParam2, TParam3, IEnumerable<TResult>> CompileQuery<TContext, TParam1, TParam2, TParam3, TResult, TProperty>(
            Expression<Func<TContext, TParam1, TParam2, TParam3,
                            IIncludableQueryable<TResult, TProperty>>> queryExpression)
            where TContext : DbContext
        {
            return (ctx, p1, p2, p3) =>
            {
                var key = (model: (object)ctx.Model, expr: (LambdaExpression)queryExpression);
                var compiled =
                    (Func<TContext, TParam1, TParam2, TParam3, IEnumerable<TResult>>)
                        _cache.GetOrAdd(key,
                                        _ => EF.CompileQuery(queryExpression));
                return compiled(ctx, p1, p2, p3);
            };
        }
        public static Func<TContext, TParam1, TParam2, TParam3, IEnumerable<TResult>> CompileQuery<TContext, TParam1, TParam2, TParam3, TResult>(
            Expression<Func<TContext, TParam1, TParam2, TParam3, IQueryable<TResult>>>
                queryExpression)
            where TContext : DbContext
        {
            return (ctx, p1, p2, p3) =>
            {
                var key = (model: (object)ctx.Model, expr: (LambdaExpression)queryExpression);
                var compiled =
                    (Func<TContext, TParam1, TParam2, TParam3, IEnumerable<TResult>>)
                        _cache.GetOrAdd(
                            key,
                            _ => EF.CompileQuery(
                                queryExpression));
                return compiled(ctx, p1, p2, p3);
            };
        }
        public static Func<TContext, TParam1, TParam2, TParam3, TResult> CompileQuery<TContext, TParam1, TParam2, TParam3, TResult>(
            Expression<Func<TContext, TParam1, TParam2, TParam3, TResult>> queryExpression)
            where TContext : DbContext
        {
            return (ctx, p1, p2, p3) =>
            {
                var key = (model: (object)ctx.Model, expr: (LambdaExpression)queryExpression);
                var compiled = (Func<TContext, TParam1, TParam2, TParam3, TResult>)_cache.GetOrAdd(
                    key,
                    _ => EF.CompileQuery(
                        queryExpression));
                return compiled(ctx, p1, p2, p3);
            };
        }
        public static Func<TContext, TParam1, TParam2, TParam3, TParam4, IEnumerable<TResult>> CompileQuery<TContext, TParam1, TParam2, TParam3, TParam4, TResult, TProperty>(
            Expression<Func<TContext, TParam1, TParam2, TParam3, TParam4,
                            IIncludableQueryable<TResult, TProperty>>> queryExpression)
            where TContext : DbContext
        {
            return (ctx, p1, p2, p3, p4) =>
            {
                var key = (model: (object)ctx.Model, expr: (LambdaExpression)queryExpression);
                var compiled =
                    (Func<TContext, TParam1, TParam2, TParam3, TParam4, IEnumerable<TResult>>)_cache
                        .GetOrAdd(key,
                                  _ => EF.CompileQuery(queryExpression));
                return compiled(ctx, p1, p2, p3, p4);
            };
        }
        public static Func<TContext, TParam1, TParam2, TParam3, TParam4, IEnumerable<TResult>> CompileQuery<TContext, TParam1, TParam2, TParam3, TParam4, TResult>(
            Expression<Func<TContext, TParam1, TParam2, TParam3, TParam4, IQueryable<TResult>>>
                queryExpression)
            where TContext : DbContext
        {
            return (ctx, p1, p2, p3, p4) =>
            {
                var key = (model: (object)ctx.Model, expr: (LambdaExpression)queryExpression);
                var compiled =
                    (Func<TContext, TParam1, TParam2, TParam3, TParam4, IEnumerable<TResult>>)
                        _cache.GetOrAdd(key,
                                        _ => EF.CompileQuery(queryExpression));
                return compiled(ctx, p1, p2, p3, p4);
            };
        }
        public static Func<TContext, TParam1, TParam2, TParam3, TParam4, TResult> CompileQuery<TContext, TParam1, TParam2, TParam3, TParam4, TResult>(
            Expression<Func<TContext, TParam1, TParam2, TParam3, TParam4, TResult>> queryExpression)
            where TContext : DbContext
        {
            return (ctx, p1, p2, p3, p4) =>
            {
                var key = (model: (object)ctx.Model, expr: (LambdaExpression)queryExpression);
                var compiled =
                    (Func<TContext, TParam1, TParam2, TParam3, TParam4, TResult>)_cache.GetOrAdd(
                        key,
                        _ => EF.CompileQuery(
                            queryExpression));
                return compiled(ctx, p1, p2, p3, p4);
            };
        }
        public static Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, IEnumerable<TResult>> CompileQuery<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TResult, TProperty>(
            Expression<Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5,
                            IIncludableQueryable<TResult, TProperty>>> queryExpression)
            where TContext : DbContext
        {
            return (ctx, p1, p2, p3, p4, p5) =>
            {
                var key = (model: (object)ctx.Model, expr: (LambdaExpression)queryExpression);
                var compiled =
                    (Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5,
                          IEnumerable<TResult>>)
                        _cache.GetOrAdd(
                            key,
                            _ => EF.CompileQuery(queryExpression));
                return compiled(ctx, p1, p2, p3, p4, p5);
            };
        }
        public static Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, IEnumerable<TResult>> CompileQuery<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TResult>(
            Expression<Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5,
                            IQueryable<TResult>>> queryExpression)
            where TContext : DbContext
        {
            return (ctx, p1, p2, p3, p4, p5) =>
            {
                var key = (model: (object)ctx.Model, expr: (LambdaExpression)queryExpression);
                var compiled =
                    (Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5,
                          IEnumerable<TResult>>)_cache
                        .GetOrAdd(key,
                                  _ => EF.CompileQuery(queryExpression));
                return compiled(ctx, p1, p2, p3, p4, p5);
            };
        }
        public static Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TResult> CompileQuery<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TResult>(
            Expression<Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TResult>>
                queryExpression)
            where TContext : DbContext
        {
            return (ctx, p1, p2, p3, p4, p5) =>
            {
                var key = (model: (object)ctx.Model, expr: (LambdaExpression)queryExpression);
                var compiled =
                    (Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TResult>)_cache
                        .GetOrAdd(key,
                                  _ => EF.CompileQuery(queryExpression));
                return compiled(ctx, p1, p2, p3, p4, p5);
            };
        }
        public static Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, IEnumerable<TResult>> CompileQuery<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TResult, TProperty>(
            Expression<Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6,
                            IIncludableQueryable<TResult, TProperty>>> queryExpression)
            where TContext : DbContext
        {
            return (ctx, p1, p2, p3, p4, p5, p6) =>
            {
                var key = (model: (object)ctx.Model, expr: (LambdaExpression)queryExpression);
                var compiled =
                    (Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6,
                          IEnumerable<TResult>>)_cache
                        .GetOrAdd(key,
                                  _ => EF.CompileQuery(
                                      queryExpression));
                return compiled(ctx, p1, p2, p3, p4, p5, p6);
            };
        }
        public static Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, IEnumerable<TResult>> CompileQuery<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TResult>(
            Expression<Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6,
                            IQueryable<TResult>>> queryExpression)
            where TContext : DbContext
        {
            return (ctx, p1, p2, p3, p4, p5, p6) =>
            {
                var key = (model: (object)ctx.Model, expr: (LambdaExpression)queryExpression);
                var compiled =
                    (Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6,
                          IEnumerable<TResult>>)_cache
                        .GetOrAdd(key,
                                  _ => EF.CompileQuery(queryExpression));
                return compiled(ctx, p1, p2, p3, p4, p5, p6);
            };
        }
        public static Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TResult> CompileQuery<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TResult>(
            Expression<Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6,
                            TResult>> queryExpression)
            where TContext : DbContext
        {
            return (ctx, p1, p2, p3, p4, p5, p6) =>
            {
                var key = (model: (object)ctx.Model, expr: (LambdaExpression)queryExpression);
                var compiled =
                    (Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TResult>)
                        _cache.GetOrAdd(
                            key,
                            _ => EF.CompileQuery(queryExpression));
                return compiled(ctx, p1, p2, p3, p4, p5, p6);
            };
        }
        public static Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, IEnumerable<TResult>> CompileQuery<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TResult, TProperty>(
            Expression<Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7,
                            IIncludableQueryable<TResult, TProperty>>> queryExpression)
            where TContext : DbContext
        {
            return (ctx, p1, p2, p3, p4, p5, p6, p7) =>
            {
                var key = (model: (object)ctx.Model, expr: (LambdaExpression)queryExpression);
                var compiled =
                    (Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7,
                          IEnumerable<TResult>>)
                        _cache.GetOrAdd(
                            key,
                            _ => EF.CompileQuery(
                                queryExpression));
                return compiled(ctx, p1, p2, p3, p4, p5, p6, p7);
            };
        }
        public static Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, IEnumerable<TResult>> CompileQuery<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TResult>(
            Expression<Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7,
                            IQueryable<TResult>>> queryExpression)
            where TContext : DbContext
        {
            return (ctx, p1, p2, p3, p4, p5, p6, p7) =>
            {
                var key = (model: (object)ctx.Model, expr: (LambdaExpression)queryExpression);
                var compiled =
                    (Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7,
                          IEnumerable<TResult>>)_cache
                        .GetOrAdd(key,
                                  _ => EF.CompileQuery(
                                      queryExpression));
                return compiled(ctx, p1, p2, p3, p4, p5, p6, p7);
            };
        }
        public static Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TResult> CompileQuery<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TResult>(
            Expression<Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7,
                            TResult>> queryExpression)
            where TContext : DbContext
        {
            return (ctx, p1, p2, p3, p4, p5, p6, p7) =>
            {
                var key = (model: (object)ctx.Model, expr: (LambdaExpression)queryExpression);
                var compiled =
                    (Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7,
                          TResult>)_cache
                        .GetOrAdd(key,
                                  _ => EF.CompileQuery(
                                      queryExpression));
                return compiled(ctx, p1, p2, p3, p4, p5, p6, p7);
            };
        }
        public static Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, IEnumerable<TResult>> CompileQuery<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TResult, TProperty>(
            Expression<Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7,
                            TParam8, IIncludableQueryable<TResult, TProperty>>> queryExpression)
            where TContext : DbContext
        {
            return (ctx, p1, p2, p3, p4, p5, p6, p7, p8) =>
            {
                var key = (model: (object)ctx.Model, expr: (LambdaExpression)queryExpression);
                var compiled =
                    (Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7,
                          TParam8, IEnumerable<TResult>>)_cache
                        .GetOrAdd(key,
                                  _ => EF.CompileQuery(queryExpression));
                return compiled(ctx, p1, p2, p3, p4, p5, p6, p7, p8);
            };
        }
        public static Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, IEnumerable<TResult>> CompileQuery<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TResult>(
            Expression<Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7,
                            TParam8, IQueryable<TResult>>> queryExpression)
            where TContext : DbContext
        {
            return (ctx, p1, p2, p3, p4, p5, p6, p7, p8) =>
            {
                var key = (model: (object)ctx.Model, expr: (LambdaExpression)queryExpression);
                var compiled =
                    (Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7,
                          TParam8, IEnumerable<TResult>>)_cache
                        .GetOrAdd(key,
                                  _ => EF.CompileQuery(
                                      queryExpression));
                return compiled(ctx, p1, p2, p3, p4, p5, p6, p7, p8);
            };
        }
        public static Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TResult> CompileQuery<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TResult>(
            Expression<Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7,
                            TParam8, TResult>> queryExpression)
            where TContext : DbContext
        {
            return (ctx, p1, p2, p3, p4, p5, p6, p7, p8) =>
            {
                var key = (model: (object)ctx.Model, expr: (LambdaExpression)queryExpression);
                var compiled =
                    (Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7,
                          TParam8, TResult>)_cache
                        .GetOrAdd(key,
                                  _ => EF.CompileQuery(
                                      queryExpression));
                return compiled(ctx, p1, p2, p3, p4, p5, p6, p7, p8);
            };
        }
        public static Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, IEnumerable<TResult>> CompileQuery<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TResult, TProperty>(
            Expression<Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7,
                            TParam8, TParam9, IIncludableQueryable<TResult, TProperty>>>
                queryExpression)
            where TContext : DbContext
        {
            return (ctx, p1, p2, p3, p4, p5, p6, p7, p8, p9) =>
            {
                var key = (model: (object)ctx.Model, expr: (LambdaExpression)queryExpression);
                var compiled =
                    (Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7,
                          TParam8, TParam9, IEnumerable<TResult>>)_cache
                        .GetOrAdd(key,
                                  _ => EF.CompileQuery(queryExpression));
                return compiled(ctx, p1, p2, p3, p4, p5, p6, p7, p8, p9);
            };
        }
        public static Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, IEnumerable<TResult>> CompileQuery<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TResult>(
            Expression<Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7,
                            TParam8, TParam9, IQueryable<TResult>>> queryExpression)
            where TContext : DbContext
        {
            return (ctx, p1, p2, p3, p4, p5, p6, p7, p8, p9) =>
            {
                var key = (model: (object)ctx.Model, expr: (LambdaExpression)queryExpression);
                var compiled =
                    (Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7,
                          TParam8, TParam9, IEnumerable<TResult>>)_cache
                        .GetOrAdd(key,
                                  _ => EF.CompileQuery(queryExpression));
                return compiled(ctx, p1, p2, p3, p4, p5, p6, p7, p8, p9);
            };
        }
        public static Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TResult> CompileQuery<TContext, TParam1, TParam2, TParam3, TParam4, TParam5,
                                           TParam6, TParam7, TParam8, TParam9, TResult>(
            Expression<Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7,
                            TParam8, TParam9, TResult>> queryExpression)
            where TContext : DbContext
        {
            return (ctx, p1, p2, p3, p4, p5, p6, p7, p8, p9) =>
            {
                var key = (model: (object)ctx.Model, expr: (LambdaExpression)queryExpression);
                var compiled =
                    (Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7,
                          TParam8, TParam9, TResult>)_cache
                        .GetOrAdd(key,
                                  _ => EF.CompileQuery(queryExpression));
                return compiled(ctx, p1, p2, p3, p4, p5, p6, p7, p8, p9);
            };
        }
        public static Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, IEnumerable<TResult>> CompileQuery<TContext, TParam1, TParam2, TParam3,
                            TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TResult, TProperty>(
            Expression<Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7,
                            TParam8, TParam9, TParam10, IIncludableQueryable<TResult, TProperty>>>
                queryExpression)
            where TContext : DbContext
        {
            return (ctx, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10) =>
            {
                var key = (model: (object)ctx.Model, expr: (LambdaExpression)queryExpression);
                var compiled =
                    (Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7,
                          TParam8, TParam9, TParam10, IEnumerable<TResult>>)
                        _cache.GetOrAdd(
                            key,
                            _ => EF.CompileQuery(queryExpression));
                return compiled(ctx, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
            };
        }
        public static Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, IEnumerable<TResult>> CompileQuery<TContext, TParam1, TParam2, TParam3,
                            TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TResult>(
            Expression<Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7,
                            TParam8, TParam9, TParam10, IQueryable<TResult>>> queryExpression)
            where TContext : DbContext
        {
            return (ctx, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10) =>
            {
                var key = (model: (object)ctx.Model, expr: (LambdaExpression)queryExpression);
                var compiled =
                    (Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7,
                          TParam8, TParam9, TParam10, IEnumerable<TResult>>)_cache
                        .GetOrAdd(key,
                                  _ => EF.CompileQuery(queryExpression));
                return compiled(ctx, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
            };
        }
        public static Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TResult> CompileQuery<TContext, TParam1, TParam2, TParam3, TParam4,
                            TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TResult>(
            Expression<Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7,
                            TParam8, TParam9, TParam10, TResult>> queryExpression)
            where TContext : DbContext
        {
            return (ctx, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10) =>
            {
                var key = (model: (object)ctx.Model, expr: (LambdaExpression)queryExpression);
                var compiled =
                    (Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7,
                          TParam8, TParam9, TParam10, TResult>)_cache
                        .GetOrAdd(key,
                                  _ => EF.CompileQuery(queryExpression));
                return compiled(ctx, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
            };
        }
        public static Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, IEnumerable<TResult>> CompileQuery<TContext, TParam1, TParam2, TParam3,
                            TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TResult, TProperty>(
            Expression<Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7,
                            TParam8, TParam9, TParam10, TParam11,
                            IIncludableQueryable<TResult, TProperty>>> queryExpression)
            where TContext : DbContext
        {
            return (ctx, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11) =>
            {
                var key = (model: (object)ctx.Model, expr: (LambdaExpression)queryExpression);
                var compiled =
                    (Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7,
                          TParam8, TParam9, TParam10, TParam11, IEnumerable<TResult>>)_cache
                        .GetOrAdd(key,
                                  _ => EF.CompileQuery(
                                      queryExpression));
                return compiled(ctx, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11);
            };
        }
        public static Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, IEnumerable<TResult>> CompileQuery<TContext, TParam1, TParam2, TParam3,
                            TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TResult>(
            Expression<Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7,
                            TParam8, TParam9, TParam10, TParam11, IQueryable<TResult>>>
                queryExpression)
            where TContext : DbContext
        {
            return (ctx, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11) =>
            {
                var key = (model: (object)ctx.Model, expr: (LambdaExpression)queryExpression);
                var compiled =
                    (Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7,
                          TParam8, TParam9, TParam10, TParam11, IEnumerable<TResult>>)
                        _cache.GetOrAdd(
                            key,
                            _ => EF.CompileQuery(queryExpression));
                return compiled(ctx, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11);
            };
        }
        public static Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TResult> CompileQuery<TContext, TParam1, TParam2, TParam3, TParam4,
                            TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TResult>(
            Expression<Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7,
                            TParam8, TParam9, TParam10, TParam11, TResult>> queryExpression)
            where TContext : DbContext
        {
            return (ctx, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11) =>
            {
                var key = (model: (object)ctx.Model, expr: (LambdaExpression)queryExpression);
                var compiled =
                    (Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7,
                          TParam8, TParam9, TParam10, TParam11, TResult>)
                        _cache.GetOrAdd(
                            key,
                            _ => EF.CompileQuery(queryExpression));
                return compiled(ctx, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11);
            };
        }
        public static Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, IEnumerable<TResult>> CompileQuery<TContext, TParam1, TParam2, TParam3,
                            TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TResult, TProperty>(
            Expression<Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7,
                            TParam8, TParam9, TParam10, TParam11, TParam12,
                            IIncludableQueryable<TResult, TProperty>>> queryExpression)
            where TContext : DbContext
        {
            return (ctx, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12) =>
            {
                var key = (model: (object)ctx.Model, expr: (LambdaExpression)queryExpression);
                var compiled =
                    (Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7,
                          TParam8, TParam9, TParam10, TParam11, TParam12, IEnumerable<TResult>>)
                        _cache.GetOrAdd(
                            key,
                            _ => EF.CompileQuery(
                                queryExpression));
                return compiled(ctx, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12);
            };
        }
        public static Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, IEnumerable<TResult>> CompileQuery<TContext, TParam1, TParam2, TParam3,
                            TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TResult>(
            Expression<Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7,
                            TParam8, TParam9, TParam10, TParam11, TParam12, IQueryable<TResult>>>
                queryExpression)
            where TContext : DbContext
        {
            return (ctx, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12) =>
            {
                var key = (model: (object)ctx.Model, expr: (LambdaExpression)queryExpression);
                var compiled =
                    (Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7,
                          TParam8, TParam9, TParam10, TParam11, TParam12, IEnumerable<TResult>>)
                        _cache.GetOrAdd(
                            key,
                            _ => EF.CompileQuery(
                                queryExpression));
                return compiled(ctx, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12);
            };
        }
        public static Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TResult> CompileQuery<TContext, TParam1, TParam2, TParam3, TParam4,
                            TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TResult>(
            Expression<Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7,
                            TParam8, TParam9, TParam10, TParam11, TParam12, TResult>>
                queryExpression)
            where TContext : DbContext
        {
            return (ctx, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12) =>
            {
                var key = (model: (object)ctx.Model, expr: (LambdaExpression)queryExpression);
                var compiled =
                    (Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7,
                          TParam8, TParam9, TParam10, TParam11, TParam12, TResult>)_cache
                        .GetOrAdd(key,
                                  _ => EF.CompileQuery(
                                      queryExpression));
                return compiled(ctx, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12);
            };
        }
        public static Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, IEnumerable<TResult>> CompileQuery<TContext, TParam1, TParam2, TParam3,
                        TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TResult, TProperty>(
            Expression<Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7,
                            TParam8, TParam9, TParam10, TParam11, TParam12, TParam13,
                            IIncludableQueryable<TResult, TProperty>>> queryExpression)
            where TContext : DbContext
        {
            return (ctx, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13) =>
            {
                var key = (model: (object)ctx.Model, expr: (LambdaExpression)queryExpression);
                var compiled =
                    (Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7,
                          TParam8, TParam9, TParam10, TParam11, TParam12, TParam13,
                          IEnumerable<TResult>>)_cache
                        .GetOrAdd(key,
                                  _ => EF.CompileQuery(queryExpression));
                return compiled(ctx, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13);
            };
        }
        public static Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, IEnumerable<TResult>> CompileQuery<TContext, TParam1, TParam2, TParam3,
                        TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TResult>(
            Expression<Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7,
                            TParam8, TParam9, TParam10, TParam11, TParam12, TParam13,
                            IQueryable<TResult>>> queryExpression)
            where TContext : DbContext
        {
            return (ctx, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13) =>
            {
                var key = (model: (object)ctx.Model, expr: (LambdaExpression)queryExpression);
                var compiled =
                    (Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7,
                          TParam8, TParam9, TParam10, TParam11, TParam12, TParam13,
                          IEnumerable<TResult>>)
                        _cache.GetOrAdd(
                            key,
                            _ => EF.CompileQuery(
                                queryExpression));
                return compiled(ctx, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13);
            };
        }
        public static Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TResult> CompileQuery<TContext, TParam1, TParam2, TParam3, TParam4,
                            TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TResult>(
            Expression<Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7,
                            TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TResult>>
                queryExpression)
            where TContext : DbContext
        {
            return (ctx, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13) =>
            {
                var key = (model: (object)ctx.Model, expr: (LambdaExpression)queryExpression);
                var compiled =
                    (Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7,
                          TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TResult>)
                        _cache.GetOrAdd(
                            key,
                            _ => EF.CompileQuery(
                                queryExpression));
                return compiled(ctx, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13);
            };
        }
        public static Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14, IEnumerable<TResult>> CompileQuery<TContext, TParam1, TParam2, TParam3,
                            TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14, TResult, TProperty>(
            Expression<Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7,
                            TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14,
                            IIncludableQueryable<TResult, TProperty>>> queryExpression)
            where TContext : DbContext
        {
            return (ctx, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14) =>
            {
                var key = (model: (object)ctx.Model, expr: (LambdaExpression)queryExpression);
                var compiled =
                    (Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7,
                          TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14,
                          IEnumerable<TResult>>)
                        _cache.GetOrAdd(
                            key,
                            _ => EF.CompileQuery(queryExpression));
                return compiled(ctx, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14);
            };
        }
        public static Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14, IEnumerable<TResult>> CompileQuery<TContext, TParam1, TParam2, TParam3,
                            TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14, TResult>(
            Expression<Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7,
                            TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14,
                            IQueryable<TResult>>> queryExpression)
            where TContext : DbContext
        {
            return (ctx, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14) =>
            {
                var key = (model: (object)ctx.Model, expr: (LambdaExpression)queryExpression);
                var compiled =
                    (Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7,
                          TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14,
                          IEnumerable<TResult>>)_cache
                        .GetOrAdd(key,
                                  _ => EF.CompileQuery(queryExpression));
                return compiled(ctx, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14);
            };
        }
        public static Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14, TResult> CompileQuery<TContext, TParam1, TParam2, TParam3, TParam4,
                            TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14, TResult>(
            Expression<Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7,
                            TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14,
                            TResult>> queryExpression)
            where TContext : DbContext
        {
            return (ctx, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14) =>
            {
                var key = (model: (object)ctx.Model, expr: (LambdaExpression)queryExpression);
                var compiled =
                    (Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14, TResult>)_cache
                        .GetOrAdd(key,
                                  _ => EF.CompileQuery(queryExpression));
                return compiled(ctx, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14);
            };
        }
        public static Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14, TParam15, IEnumerable<TResult>> CompileQuery<TContext, TParam1, TParam2, TParam3, TParam4,
                            TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14, TParam15, TResult, TProperty>(
            Expression<Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7,
                            TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14,
                            TParam15, IIncludableQueryable<TResult, TProperty>>> queryExpression)
            where TContext : DbContext
        {
            return (ctx, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15) =>
            {
                var key = (model: (object)ctx.Model, expr: (LambdaExpression)queryExpression);
                var compiled =
                    (Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7,
                          TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14,
                          TParam15, IEnumerable<TResult>>)
                        _cache.GetOrAdd(
                            key,
                            _ => EF.CompileQuery(queryExpression));
                return compiled(ctx, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15);
            };
        }
        public static Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14, TParam15, IEnumerable<TResult>> CompileQuery<TContext, TParam1, TParam2, TParam3, TParam4,
                            TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14, TParam15, TResult>(
            Expression<Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7,
                            TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14,
                            TParam15, IQueryable<TResult>>> queryExpression)
            where TContext : DbContext
        {
            return (ctx, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15) =>
            {
                var key = (model: (object)ctx.Model, expr: (LambdaExpression)queryExpression);
                var compiled =
                    (Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7,
                          TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14,
                          TParam15, IEnumerable<TResult>>)
                        _cache.GetOrAdd(
                            key,
                            _ => EF.CompileQuery(queryExpression));
                return compiled(ctx, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15);
            };
        }
        public static Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14, TParam15, TResult> CompileQuery<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6,
                            TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14, TParam15, TResult>(
            Expression<Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7,
                            TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14,
                            TParam15, TResult>> queryExpression)
            where TContext : DbContext
        {
            return (ctx, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15) =>
            {
                var key = (model: (object)ctx.Model, expr: (LambdaExpression)queryExpression);
                var compiled =
                    (Func<TContext, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7,
                          TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14,
                          TParam15, TResult>)
                        _cache.GetOrAdd(
                            key,
                            _ => EF.CompileQuery(queryExpression));
                return compiled(ctx, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15);
            };
        }
    }
}
