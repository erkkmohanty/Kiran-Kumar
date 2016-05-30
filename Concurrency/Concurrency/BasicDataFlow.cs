using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Concurrency
{
    class BasicDataFlow
    {
        internal static void CreateMesh()
        {
            var multiplyBlock = new TransformBlock<int, int>(item => item * 2);
            var subtractBlock = new TransformBlock<int, int>(item => item - 2);
            multiplyBlock.LinkTo(subtractBlock);
            multiplyBlock.Post(90);
            multiplyBlock.Complete();
            subtractBlock.Complete();
        }

        internal async static void CreateMeshWithResultPropagation()
        {
            var multiplyBlock = new TransformBlock<int, int>(item => item * 2);
            var subtractBlock = new TransformBlock<int, int>(item => item - 2);
            var options = new DataflowLinkOptions { PropagateCompletion = true };
            multiplyBlock.LinkTo(subtractBlock, options);
            // The first block's completion is automatically propagated to the second block.
            multiplyBlock.Complete();
            await subtractBlock.Completion;
        }
    }
}
