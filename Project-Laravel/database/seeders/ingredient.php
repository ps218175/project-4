<?php

namespace Database\Seeders;

use Illuminate\Database\Seeder;
use App\Models\Ingridienten;

class ingredient extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
        //
        $ingredients = [
            ['naam_ingr' => 'kaas', 'unit' => 1, 'prijs_ingr' => 0.44 ],
            ['naam_ingr' => 'tomatensaus', 'unit' => 2, 'prijs_ingr' => 0.54],
            ['naam_ingr' => 'Kabab', 'unit' => 3, 'prijs_ingr' => 0.24],
        ];

        foreach($ingredients as $ingredient){
            Ingridienten::create($ingredient);
        }

    }
}
