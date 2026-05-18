    using AutoMapper;
    using PrinudnaNaplata.Models.Dtos.Client;
    using PrinudnaNaplata.Repositories.Interfaces;
    using PrinudnaNaplata.Results;
    using PrinudnaNaplata.Services.Interfaces;

    namespace PrinudnaNaplata.Services.Implementations
    {
        public class ClientService : IClientService
        {
            private readonly IClientRepository clientRepository;
            private readonly IMapper mapper;

            public ClientService(IClientRepository clientRepository, IMapper mapper)
            {
                this.clientRepository = clientRepository;
                this.mapper = mapper;
            }

            public async Task<Result<List<ClientListResponseDto>>> GetAllAsync()
            {
                var clientsDomain = await clientRepository.GetAllAsync();

                var result = mapper.Map<List<ClientListResponseDto>>(clientsDomain);

                return Result<List<ClientListResponseDto>>.Ok(result);
            }
        }
    }
