<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Pizza extends Model
{
    protected $fillable = [
        'naam','beschrijving', 'prijs',
    ];
    public function Ingredientrel()
    {
        return $this->belongsToMany('App\Ingredient');
    }
}