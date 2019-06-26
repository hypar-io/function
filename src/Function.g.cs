// This code was generated by Hypar.
// Edits to this code will be overwritten the next time code generation occurs.
// DO NOT EDIT THIS FILE.
using Amazon;
using Amazon.Lambda.Core;
using Hypar.Functions.Execution;
using Hypar.Functions.Execution.AWS;
using System.Threading.Tasks;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]
namespace Hypar
{
	public class Function
	{
		// Cache the model store for use by subsequent
		// executions of this lambda.
		private IModelStore store;

		public async Task<HyparOutputs> Handler(HyparInputs args, ILambdaContext context)
		{
			if(this.store == null)
			{
				this.store = new S3ModelStore(args, RegionEndpoint.USWest1);
			}
			
			var l = new InvocationWrapper<HyparInputs,HyparOutputs>(store, Hypar.Execute);
			var output = await l.InvokeAsync(args);
			return output;
		}
  	}
}