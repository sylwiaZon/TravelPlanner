package com.travelplanner.ui.allTravels

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.TextView
import androidx.fragment.app.Fragment
import androidx.lifecycle.Observer
import androidx.lifecycle.ViewModelProvider
import com.travelplanner.R

class AllTravelsFragment : Fragment() {

    private lateinit var allTravelsViewModel: AllTravelsViewModel

    override fun onCreateView(
            inflater: LayoutInflater,
            container: ViewGroup?,
            savedInstanceState: Bundle?
    ): View? {
        allTravelsViewModel =
                ViewModelProvider(this).get(AllTravelsViewModel::class.java)
        val root = inflater.inflate(R.layout.fragment_all_travels, container, false)
        val textView: TextView = root.findViewById(R.id.text_slideshow)
        allTravelsViewModel.travelsList.observe(viewLifecycleOwner, Observer {
            textView.text = it.size.toString()
        })
        return root
    }
}