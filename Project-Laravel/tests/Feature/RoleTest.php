<?php

namespace Tests\Feature;

use App\Http\Controllers\RoleController;
use App\Models\Role;
use App\Models\User;
use App\Models\UserRole;
use Carbon\Factory;
use Illuminate\Foundation\Testing\RefreshDatabase;
use Illuminate\Foundation\Testing\WithFaker;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Auth;
use Tests\TestCase;

class RoleTest extends TestCase
{
    /**
     * A basic feature test example.
     *
     * @return void
     */
    use RefreshDatabase;
    public function test_endpoint_get_role(){
        // maak een user aan
        $user = User::factory()->create([
            'name' => 'Test',
            'email' => 'test@test.test',
            // note you need to use the bcrypt function here to hash your password
            'password' => bcrypt('password')
        ]);
        // user login (hoeft niet dooe actingAs)
        // Auth::login($user);
        // als user ga naar endpoint role
        $response = $this->actingAs($user)->get('/role');
        // endpoint gehaald?
        $response->assertStatus(200);
        // zitten we in de juiste view?
        $response->assertSee('Rollen');
    }

    public function test_endpoint_role_index_view(){
        $user = User::factory()->create([
            'name' => 'Test',
            'email' => 'test@test.test',
            // note you need to use the bcrypt function here to hash your password
            'password' => bcrypt('password')
        ]);
        $response = $this->actingAs($user)->get('/role');
        // zitten we in de juiste view?
        $response->assertSee('Rollen');
    }

    public function test_store_method_role(){
        $roleController = new RoleController();
        $roleController->store(new Request([
            'name' => 'manager'
        ]));
        $this->assertDatabaseHas('roles', [
            'name' => 'manager'
        ]);
    }

    public function test_update_method_role(){
        Role::create([
            'name' => 'manager'
        ]);
        $roleController = new RoleController();
        $roleController->update([
            'name' => 'admin'
        ], 1);
        $this->assertDatabaseHas('roles', [
            'name' => 'admin'
        ]);
    }

    public function test_destroy_method_role(){
        Role::create([
            'name' => 'manager'
        ]);
        $roleController = new RoleController();
        $roleController->destroy(1);
        $this->assertCount(0, Role::all());
    }
}
