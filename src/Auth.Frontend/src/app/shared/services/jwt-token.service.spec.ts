import { describe, it, expect, vi, beforeEach } from 'vitest';
import { JwtTokenService } from './jwt-token.service';
import { LocalStorageService } from './local-storage.service';

// Mock LocalStorageService
class MockLocalStorageService {
  private store: Record<string, string> = {};
  set(key: string, value: string) { this.store[key] = value; }
  get(key: string) { return this.store[key]; }
  remove(key: string) { delete this.store[key]; }
}

describe('JwtTokenService', () => {
  let service: JwtTokenService;
  let localStorageService: MockLocalStorageService;

  beforeEach(() => {
    localStorageService = new MockLocalStorageService();
    service = new JwtTokenService(localStorageService as any);
  });

  it('should save and get token', () => {
    service.safeToken('abc');
    expect(service.getToken()).toBe('abc');
  });

  it('should remove token', () => {
    service.safeToken('abc');
    service.removeToken();
    expect(service.getToken()).toBeUndefined();
  });

  it('should return undefined user if no token', () => {
    expect(service.getUser()).toBeUndefined();
  });

  it('should return false for isExpTokenValid if no token', () => {
    expect(service.isExpTokenValid()).toBe(false);
  });
});
