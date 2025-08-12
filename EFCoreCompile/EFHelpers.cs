using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Concurrent;
using System.Linq.Expressions;

namespace EFCoreCompile
{
    public static class EFWrap
    {
        // Each overload gets its own typed cache to avoid boxing/casting issues
        private static readonly ConcurrentDictionary<(object model, LambdaExpression expr), object> _cache = new();

        // 0 parameters
        public static Func<TContext, TResult> CompileQuery<TContext, TResult>(
            Expression<Func<TContext, TResult>> query)
            where TContext : DbContext
        {
            return ctx =>
            {
                var key = (ctx.Model, (LambdaExpression)query);
                var compiled = (Func<TContext, TResult>)_cache.GetOrAdd(
                    key, _ => EF.CompileQuery(query));
                return compiled(ctx);
            };
        }

        // 1 parameter
        public static Func<TContext, TParam1, TResult> CompileQuery<TContext, TParam1, TResult>(
            Expression<Func<TContext, TParam1, TResult>> query)
            where TContext : DbContext
        {
            return (ctx, p1) =>
            {
                var key = (ctx.Model, (LambdaExpression)query);
                var compiled = (Func<TContext, TParam1, TResult>)_cache.GetOrAdd(
                    key, _ => EF.CompileQuery(query));
                return compiled(ctx, p1);
            };
        }

        // 2 parameters
        public static Func<TContext, TParam1, TParam2, TResult> CompileQuery<TContext, TParam1, TParam2, TResult>(
            Expression<Func<TContext, TParam1, TParam2, TResult>> query)
            where TContext : DbContext
        {
            return (ctx, p1, p2) =>
            {
                var key = (ctx.Model, (LambdaExpression)query);
                var compiled = (Func<TContext, TParam1, TParam2, TResult>)_cache.GetOrAdd(
                    key, _ => EF.CompileQuery(query));
                return compiled(ctx, p1, p2);
            };
        }
    }
}
