using CopilotHere.Infrastructure;
using TUnit.Core;

namespace CopilotHere.Tests;

public class SystemInfoTests
{
  [Test]
  public async Task GetUserId_ReturnsNonEmptyString()
  {
    // Act
    var userId = SystemInfo.GetUserId();

    // Assert
    await Assert.That(userId).IsNotNull();
    await Assert.That(userId).IsNotEmpty();
  }

  [Test]
  public async Task GetGroupId_ReturnsNonEmptyString()
  {
    // Act
    var groupId = SystemInfo.GetGroupId();

    // Assert
    await Assert.That(groupId).IsNotNull();
    await Assert.That(groupId).IsNotEmpty();
  }

  [Test]
  public async Task SupportsEmoji_ReturnsBool()
  {
    // Act
    var result = SystemInfo.SupportsEmoji();

    // Assert - just verify it doesn't throw and returns a boolean
    await Assert.That(result).IsTypeOf<bool>();
  }

  [Test]
  public async Task IsSelinuxEnforcing_ReturnsBool()
  {
    // Act - should not throw regardless of the host's SELinux state
    var result = SystemInfo.IsSelinuxEnforcing();

    // Assert
    await Assert.That(result).IsTypeOf<bool>();
  }

  [Test]
  public async Task IsSelinuxEnforcing_ReturnsFalseOnNonLinux()
  {
    // On non-Linux OSes (Windows, macOS), SELinux is never enforcing
    if (OperatingSystem.IsLinux()) return; // Skip on Linux where result depends on host

    var result = SystemInfo.IsSelinuxEnforcing();
    await Assert.That(result).IsFalse();
  }
}
