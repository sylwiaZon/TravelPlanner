package com.travelplanner.ui.cityWalk

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Button
import android.widget.EditText
import androidx.fragment.app.Fragment
import androidx.lifecycle.ViewModelProvider
import com.travelplanner.R

class SearchCityWalkFragment : Fragment() {
    lateinit var viewModel: CityWalkViewModel
    var travelId: String = ""
    var cityName: String = ""

    override fun onCreateView(inflater: LayoutInflater, container: ViewGroup?, savedInstanceState: Bundle?): View? {
        val v = inflater.inflate(R.layout.add_new_city_walk, container, false)
        viewModel =
                ViewModelProvider(this).get(CityWalkViewModel::class.java)

        val input = v.findViewById<EditText>(R.id.city_walk_duration_input)
        val button = v.findViewById<Button>(R.id.search_city_walk_button)
        button.visibility = View.VISIBLE
        button.setOnClickListener {
            val duration = input.text.toString().toInt()
            viewModel.getCityWalk(cityName, duration,travelId)
        }
        return v
    }

    fun setData(tr: String, cName: String) {
        travelId = tr
        cityName = cName
    }
}