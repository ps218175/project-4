<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Ingredient extends Model
{
    protected $fillable = [
        'ingredient_id', 'ingredient_1', 'ingredient_2', 'ingredient_3', 'ingredient_4',
    ];
    public function PizzaRel()
    {
        return $this->belongsToMany('App\Pizza');
    }
}