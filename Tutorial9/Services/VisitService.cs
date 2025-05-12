using Tutorial9.Model.DTO;

namespace Tutorial9.Services
{
    public class VisitService : IVisitService
    {
        private readonly IVisitService _repository;

        public VisitService(IVisitService repository)
        {
            _repository = repository;
        }

        public async Task<VisitDTO> GetVisitByIdAsync(int visitId)
        {
            var visit = await _repository.GetVisitByIdAsync(visitId);

            if (visit == null)
                throw new KeyNotFoundException("Visit not found");

            return visit;
        }

        public async Task<bool> AddVisitAsync(VisitDTO visitDto)
        {
            return await _repository.AddVisitAsync(visitDto);
        }

        public class ClientService : IClientService
        {
            private readonly IClientService _repository;

            public ClientService(IClientService repository)
            {
                _repository = repository;
            }

            public async Task<ClientDTO> GetClientByIdAsync(int clientId)
            {
                var client = await _repository.GetClientByIdAsync(clientId);
                
                if (client == null)
                    throw new KeyNotFoundException("Client not found");
                
                return client;
            }
            
            
        }

        public class MechanicService : IMechanicService
        {
            private readonly IMechanicService _repository;

            public MechanicService(IMechanicService repository)
            {
                _repository = repository;
            }

            public async Task<MechanicDTO> GetMechanicByLicenceAsync(string licenceNumber)
            {
                var mechanic = await _repository.GetMechanicByLicenceAsync(licenceNumber);

                if (mechanic == null)
                    throw new KeyNotFoundException("Mechanic not found");
                
                return mechanic;
            }
        }
    }
}