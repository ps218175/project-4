<?php

namespace App\Http\Controllers;

use App\Models\Size;
use App\Models\Pizza;
use Darryldecode\Cart\Cart;
use Illuminate\Http\Request;

class Cartcontroller extends Controller
{
    public function cartList()
    {
        $cartItems = \Cart::getContent();
        // dd($cartItems);
        return view('cart', compact('cartItems'));

       
    }


    public function addToCart(Request $request)
    {
        \Cart::add([
            'id' => $request->id,
            'name' => $request->name,
            'price' => $request->amount,
            'quantity' => $request->quantity,
         
         
        ]);
        session()->flash('success', 'Product is Added to Cart Successfully !');

        return redirect()->route('cart.list');
    }

    public function updateCart(Request $request)
    {
        \Cart::update(
            $request->id,
            [
                'quantity' => [
                    'relative' => false,
                    'value' => $request->quantity
                ],
            ]
        );

        session()->flash('success', 'Item Cart is Updated Successfully !');

        return redirect()->route('cart.list');
    }

    public function removeCart(Request $request)
    {
        \Cart::remove($request->id);
        session()->flash('success', 'Item Cart Remove Successfully !');

        return redirect()->route('cart.list');
    }

    public function clearAllCart()
    {
        \Cart::clear();

        session()->flash('success', 'All Item Cart Clear Successfully !');

        return redirect()->route('cart.list');

      
    }
    public function alert(){
        $count = \Cart::getContent()->count();
        if ($count < 1) {
            session()->flash('error', 'u heeft nog geen pizza gekozen');

        return redirect()->route('cart.list');
        }
        else{
            $order = Pizza::all();

            return view('klantbestel', ['pizza' => $order]);
        }
    }
}