using System;

namespace DataPipeline.Net.Core
{
    public enum DataPipelineRunState
    {
        Init = 0,
        Extract,
        Transform,
        Load,
        Complete
    }

    public class DataPipeline : IDataPipeline
    {
        private readonly RawZone _rawZone;

        private readonly CuratedZone _curatedZone;

        public DataPipelineRunState RunState { get; private set; }

        public DataPipeline(IDataExtractor dataExtractor, IDataLoader dataLoader)
        {
            _rawZone = new RawZone(dataExtractor);

            _curatedZone = new CuratedZone(dataLoader);

            RunState = DataPipelineRunState.Init;
        }

        public bool Run()
        {
            try
            {
                RunState = DataPipelineRunState.Extract;

                _rawZone.extractData();

                RunState = DataPipelineRunState.Transform;

                _curatedZone.curateData();

                RunState = DataPipelineRunState.Load;

                _curatedZone.loadData();

                RunState = DataPipelineRunState.Complete;

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
