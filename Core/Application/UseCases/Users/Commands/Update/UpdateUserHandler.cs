﻿using Domain.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.UseCases.Users.Commands.Update;

public class UpdateUserHandler : IRequestHandler<UpdateUserRequest, UpdateUserResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UpdateUserHandler(IUnitOfWork unitOfWork,
                             IUserRepository userRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
        _mapper = mapper;
    }
    public async Task<UpdateUserResponse> Handle(UpdateUserRequest command, CancellationToken cancellationToken)
    {
        var user = await _userRepository.Get(command.Id, cancellationToken);

        if (user is null) return default;

        user.FirstName = command.FirstName;
        user.LastName = command.LastName;
        user.Email = command.Email;

        _userRepository.Update(user);

        await _unitOfWork.Commit(cancellationToken);

        return _mapper.Map<UpdateUserResponse>(user);
    }
}