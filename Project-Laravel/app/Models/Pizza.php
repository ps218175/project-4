<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Pizza extends Model
{
    use HasFactory;
    public $table = 'pizzas';
    protected $fillable = [
        'naam','description', 'amount',
    ];
    public function Ingredientrel()
    {
        return $this->belongsToMany(Ingredient::class,'ingredient_pizzas');
    }
}
