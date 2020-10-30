using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace Spors.Blazor
{
    public class Interop : IAsyncDisposable
    {
        private readonly Lazy<Task<IJSObjectReference>> moduleTask;

        public Interop(IJSRuntime runtime)
        {
            moduleTask = new(() => runtime.InvokeAsync<IJSObjectReference>(
               "import", "./_content/Spors.Blazor/spors-blazor.js").AsTask());
        }

        public async ValueTask<bool> IsSupported(string property)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<bool>("supportsProperty", property);
        }

        public async ValueTask DisposeAsync()
        {
            if (moduleTask.IsValueCreated)
            {
                var module = await moduleTask.Value;
                await module.DisposeAsync();
            }
        }
    }
}
