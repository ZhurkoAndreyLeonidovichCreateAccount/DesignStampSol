using BuissnesLayer;
using DesignStamp.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignStamp
{
   public class ServicesManager
    {
        DataManager _dataManager;
        private DetailSevice _detailService;
        private AllForceService _forceService;
        private MatrixService _matrixService;
        private HolderService _holderService;
        private BottomPlatesService _bottomPlatesService;
        private TopPlatesService _topPlatesService;
        private PunchMatrixService _punchMatrixService;
        private PullerService _pullerService;
        private StampService _stampService;
        private CoverService _coverService;
        private ColumnService _columnService;
        private BushingService _bushingService;
        private SpringService _springService;
        private PunchService _punchService;
        private EnlargedPunchService _enlargedPunchService;
        private PressService _pressService;


        //private DifferHoleService _differHoleService;

        public ServicesManager(DataManager dataManager)          
        {
            _dataManager = dataManager;

            _detailService = new DetailSevice(_dataManager);
            _forceService = new AllForceService(_dataManager);
            _matrixService =new MatrixService(_dataManager);
            _holderService = new HolderService(_dataManager);
            _bottomPlatesService = new BottomPlatesService(_dataManager);
            _topPlatesService = new TopPlatesService(_dataManager);
            _punchMatrixService = new PunchMatrixService(_dataManager);
            _pullerService = new PullerService(_dataManager);
            _stampService = new StampService(_dataManager);
            _coverService = new CoverService(_dataManager);
            _columnService = new ColumnService(_dataManager);
            _bushingService = new BushingService(_dataManager);
            _springService = new SpringService(_dataManager);
            _punchService = new PunchService(_dataManager);
            _enlargedPunchService = new EnlargedPunchService(_dataManager);
            _pressService = new PressService(_dataManager);
        }

        public DetailSevice Details { get { return _detailService; } }
        public AllForceService AllForces { get { return _forceService; } }
        public MatrixService Matrices { get { return _matrixService; } }
        public HolderService Holders { get { return _holderService; } }
        public BottomPlatesService BottomPlates { get { return _bottomPlatesService; } }
        public TopPlatesService TopPlates { get { return _topPlatesService; } }
        public PunchMatrixService PunchMatrices { get { return _punchMatrixService; } }
        public PullerService Pullers { get { return _pullerService; } }
        public StampService Stamps { get { return _stampService; } }
        public CoverService Covers { get { return _coverService; } }
        public ColumnService Columns { get { return _columnService; } }
        public BushingService Bushings { get { return _bushingService; } }
        public SpringService Springs { get { return _springService; } }
        public PunchService Punches { get { return _punchService; } }
        public EnlargedPunchService EnlargedPunches { get { return _enlargedPunchService; } }
        public PressService Presses { get { return _pressService; } }


        //public DifferHoleService DifferHoles { get { return _differHoleService; } }

    }
}
