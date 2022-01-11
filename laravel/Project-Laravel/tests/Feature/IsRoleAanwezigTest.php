<?php

namespace Tests\Feature;

use App\Http\Controllers\Auth\RegisteredUserController;
use App\Models\Role;
use App\Models\UserRole;
use Illuminate\Foundation\Testing\RefreshDatabase;
use Illuminate\Http\Request;
use Tests\TestCase;

class IsRoleAanwezig extends TestCase
{
    /**
     * DUJO
     * Is er een role indien een gebruiker zich registreert via website
     * Is die role van klant (id = 0)
     * @return void
     * Gebruik RefreshDatabase voor reset database
     */
    use RefreshDatabase;

    public function test_is_role_van_klant_aanwezig_aanmaken_klant_uit_controller()
    {
        // Eerst een role in role table aanmaken
        Role::create(['id' => 1, 'name' => 'klant']);
        // Test of de role van klant aanwezig is bij het registreren van een klant
        // vanuit de controller
        $registeredUserController = new RegisteredUserController();
        $request = new Request([
            "name" => "test",
            "email" => "test@test.test",
            "password" => "password",
            "password_confirmation" => "password",
        ]);
        $registeredUserController->store($request);
        $this->assertDatabaseHas('user_roles', ['role_id' => 1]);
    }
}
