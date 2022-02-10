@extends('layouts.frontend')


@section('content')

<style>
  h1{
margin: 20% 20% 20% 20%;
  }
</style>
<main class="my-8">
  <div class="container px-6 mx-auto">
    <div class="flex justify-center my-6">
      <div class="flex flex-col w-full p-8 text-gray-800 bg-white shadow-lg pin-r pin-y md:w-4/5 lg:w-4/5">
        @if ($message = Session::get('success'))
        <div class="p-4 mb-3 bg-green-400 rounded">
          <p class="text-green-800">{{ $message }}</p>
        </div>
        @endif
        @if ($message = Session::get('error'))
        <div class="p-4 mb-3 bg-yellow-400 rounded">
          <p class="text-green-800">{{ $message }}</p>
        </div>
        @endif
        <h3 class="text-3xl text-bold">Cart List</h3>
        <div class="flex-6">
          <table class="w-full text-sm lg:text-base" cellspacing="0">
            <thead>
              <tr class="h-12 uppercase">
                <th class="hidden md:table-cell"></th>
                <th class="text-left">Name</th>
                  <th class="text-left">size</th>
     
                <th class="pl-5 text-left lg:text-right lg:pl-0">
                  <span class="lg:hidden" title="Quantity">Qtd</span>
       
                  <span class="hidden lg:inline">Quantity</span>
                </th>
                <th class="hidden text-right md:table-cell"> price</th>
                <th class="hidden text-right md:table-cell"> Remove </th>
              </tr>
            </thead>
            <tbody>
              @foreach ($cartItems as $item)
              <tr>
                <td class="hidden pb-4 md:table-cell">
                  <a href="#">
                    <img src="https://th.bing.com/th/id/OIP.xTHQ1Am8pYXCzw2xCSY3ZgHaFS?w=282&h=202&c=7&r=0&o=5&dpr=1.25&pid=1.7img/logo.png" class="w-20 rounded" alt="Thumbnail">
                  </a>
                </td>
                <td>
                  <a href="#">
                    <p class="mb-2 md:ml-4">{{ $item->name }}</p>

                  </a>
                </td>
                <td class="w20">
                <select name="id_jenis_surat" class="form-control">
         <option>25cm</option>
         <option  > 30cm </option> 
            <option  > 35cm </option> 
         
        </select>
                </td>
                <td class="justify-center mt-6 md:justify-end md:flex">
                  <div class="h-10 w-28">
                    <div class="relative flex flex-row w-full h-9">

                      <form action="{{ route('cart.update') }}" method="POST">
                        @csrf
                        <input type="hidden" name="id" value="{{ $item->id}}">
                        <input type="number" name="quantity" value="{{ $item->quantity }}" class="w-6 text-center bg-gray-300" />
                        <button type="submit" class="px-2 pb-2 ml-2 text-white bg-blue-500">update</button>
                      </form>
                    </div>
                  </div>
                </td>
                <td class="hidden text-right md:table-cell">
                  <span class="text-sm font-medium lg:text-base">
                    €{{ $item->price }}
                  </span>
                </td>
                <td class="hidden text-right md:table-cell">
                  <form action="{{ route('cart.remove') }}" method="POST">
                    @csrf
                    <input type="hidden" value="{{ $item->id }}" name="id">
                    <button class="px-4 py-2 text-white bg-red-600">x</button>
                  </form>

                </td>
              </tr>
              @endforeach

            </tbody>
          </table>
          <div>
            Total: €{{ Cart::getTotal() }}
          </div>
          <div>
            <form action="{{ route('cart.clear') }}" method="POST">
              @csrf
              <button onclick="toggle();" class="px-6 py-2 text-red-800 bg-red-300">Remove All Cart</button>
            </form>
            <div>
              <a href="klantbestel" class="px-6 py-2 text-red-800 bg-blue-300">bestellen</a>
            </div>
          </div>

        </div>
      </div>
    </div>
  </div>
  <div class="relative flex items-top justify-center min-h-screen bg-gray-100 dark:bg-gray-900 sm:items-center py-4 sm:pt-0">
            @if (Route::has('login'))
                <div class="hidden fixed top-0 right-0 px-6 py-4 sm:block">
                    @auth
                        <a href="{{ url('/dashboard') }}" class="text-sm text-red-500 dark:text-indigo-600 underline">Dashboard</a>
                    @else
                        <a href="{{ route('login') }}" class="text-sm text-red-500 dark:text-indigo-600 underline">Log in</a>

                        @if (Route::has('register'))
                            <a href="{{ route('register') }}" class="text-sm text-red-500 dark:text-indigo-600 underline ml-4 text-sm text-gray-700 dark:text-gray-500 underline">Register</a>
                        @endif
                    @endauth
                </div>
            @endif

            
        </div>
</main>
@endsection