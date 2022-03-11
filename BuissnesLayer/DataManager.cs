using BuissnesLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuissnesLayer
{
    public class DataManager
    {
        IDetailsRepository _detailsRepository;
        IAllForcesRepository _allForcesRepository;
        IMatricesRepository _matricesRepository;
        IHoldersRepository _holdersRepository;
        IBottomPlatesRepository _bottomPlatesRepository;
        ITopPlatesRepository _topPlatesRepository;
        IPunchMatrixRepository _punchMatrixRepository;
        ISpringsRepository _springsRepository;
        IPullersRepository _pullersRepository;
        IBushingsRepository _bushingsRepository;
        IColumnsRepository _columnsRepository;
        IPunchesRepository _punchesRepository;
        IEnlargedPunchesRepository _enlargedPunchesRepository;
        IStampsRepository _stampsRepository;
        ICoversRepository _coversRepository;
        IPressesRepository _pressesRepository;
        IPunchesIDRepository _punchesIDRepository;
        IEnlargedPunchesIDRepository _enlargedPunchesIDRepository;
        
        public DataManager(IDetailsRepository detailsRepository,IAllForcesRepository allForcesRepository, 
            IMatricesRepository matricesRepository, IHoldersRepository holdersRepository, 
            IBottomPlatesRepository bottomPlatesRepository, ITopPlatesRepository topPlatesRepository, IPunchMatrixRepository punchMatrixRepository, 
            ISpringsRepository springsRepository, IPullersRepository pullersRepository, 
            IBushingsRepository bushingsRepository, IColumnsRepository columnsRepository, 
            IPunchesRepository punchesRepository, IEnlargedPunchesRepository enlargedPunchesRepository, 
            IStampsRepository stampsRepository, ICoversRepository coversRepository, IPressesRepository pressesRepository, 
            IPunchesIDRepository punchesIDRepository, IEnlargedPunchesIDRepository enlargedPunchesIDRepository)
            
        {
            _holdersRepository = holdersRepository;
            _detailsRepository = detailsRepository;
            _allForcesRepository = allForcesRepository;
            _matricesRepository = matricesRepository;
            _bottomPlatesRepository = bottomPlatesRepository;
            _topPlatesRepository = topPlatesRepository;
            _punchMatrixRepository = punchMatrixRepository;
            _springsRepository = springsRepository;
            _pullersRepository = pullersRepository;
            _bushingsRepository = bushingsRepository;
            _columnsRepository = columnsRepository;
            _punchesRepository = punchesRepository;
            _enlargedPunchesRepository = enlargedPunchesRepository;
            _stampsRepository = stampsRepository;
            _coversRepository = coversRepository;
            _pressesRepository = pressesRepository;
            _punchesIDRepository = punchesIDRepository;
            _enlargedPunchesIDRepository = enlargedPunchesIDRepository;
            
        }

        public IDetailsRepository Details { get { return _detailsRepository; } }
        public IAllForcesRepository AllForces { get { return _allForcesRepository; } }
        public IMatricesRepository Matrices { get {return _matricesRepository; } }
        public IHoldersRepository Holders { get { return _holdersRepository; } }
        public IBottomPlatesRepository BottomPlates { get { return _bottomPlatesRepository; } }
        public ITopPlatesRepository TopPlates { get { return _topPlatesRepository; } }
        public IPunchMatrixRepository PunchMatrices { get { return _punchMatrixRepository; } }
        public ISpringsRepository Springs { get { return _springsRepository; } }
        public IPullersRepository Pullers { get { return _pullersRepository; } }
        public IBushingsRepository Bushings { get { return _bushingsRepository; } }
        public IColumnsRepository Columns { get { return _columnsRepository; } }
        public IPunchesRepository Punches { get { return _punchesRepository; } }
        public IEnlargedPunchesRepository EnlargedPunches { get { return _enlargedPunchesRepository; } }
        public IStampsRepository Stamps { get { return _stampsRepository; } }
        public ICoversRepository Covers { get { return _coversRepository; } }
        public IPressesRepository Presses { get { return _pressesRepository; } }
        public IPunchesIDRepository  PunchesID { get { return _punchesIDRepository; } }
        public IEnlargedPunchesIDRepository EnlargedPunchesID { get { return _enlargedPunchesIDRepository; } }

    }   
}
