import { TestBed } from '@angular/core/testing';
import { AdminUserService } from './admin-user.service';
import { ApiHttpService } from './api-http.service';
import { of } from 'rxjs';
import { describe, it, expect, beforeEach, vi } from 'vitest';

describe('AdminUserService', () => {
  let service: AdminUserService;
  let httpMock: any;

  beforeEach(() => {
    httpMock = {
      get: vi.fn(),
      patch: vi.fn(),
      post: vi.fn()
    };

    TestBed.configureTestingModule({
      providers: [
        AdminUserService,
        { provide: ApiHttpService, useValue: httpMock }
      ]
    });
    service = TestBed.inject(AdminUserService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should fetch users', () => {
    const mockUsers = [{ id: 1, firstName: 'Test', lastName: 'User' }];
    httpMock.get.mockReturnValue(of({ data: mockUsers, succeeded: true }));

    service.getUsers().subscribe(response => {
      expect(response.data).toEqual(mockUsers);
      expect(httpMock.get).toHaveBeenCalledWith('/v1/users');
    });
  });

  it('should change user role', () => {
    httpMock.patch.mockReturnValue(of({ data: true, succeeded: true }));

    service.changeRole(1, 'Admin').subscribe(response => {
      expect(response.data).toBe(true);
      expect(httpMock.patch).toHaveBeenCalledWith('/v1/users/1/role', { roleName: 'Admin' });
    });
  });

  it('should fetch roles', () => {
    const mockRoles = ['Admin', 'User'];
    httpMock.get.mockReturnValue(of({ data: mockRoles, succeeded: true }));

    service.getRoles().subscribe(response => {
      expect(response.data).toEqual(mockRoles);
      expect(httpMock.get).toHaveBeenCalledWith('/v1/users/roles');
    });
  });
});
