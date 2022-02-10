<?php

namespace Database\Seeders;

use App\Models\Pizza;
use Illuminate\Database\Seeder;

class pizzaseeder extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
        
        $pizzas = [
            ['name' => 'Hawai', 'description' => 'Heerlijke pizza', 'amount' => '5.99' ],
            ['name' => 'Vlees', 'description' => 'Heerlijke pizza', 'amount' => '6.99'],
            ['name' => 'Kabab', 'description' => 'Heerlijke pizza', 'amount' => '8.99'],
        ];

        foreach($pizzas as $pizza){
            Pizza::create($pizza);
        }
    
    }
}
